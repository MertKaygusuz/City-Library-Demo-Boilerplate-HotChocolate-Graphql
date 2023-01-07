using static CityLibraryInfrastructure.Statics.Methods.TokenRelated;
using CityLibraryApi.MapperConfigurations;
using CityLibraryDomain.ContextRelated;
using CityLibraryDomain.DbBase.Repositories.Base;
using CityLibraryDomain.UnitOfWorks;
using CityLibraryInfrastructure.AppSettings;
using CityLibraryInfrastructure.DbBase;
using CityLibraryInfrastructure.MapperConfigurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using System.Globalization;
using System.Reflection;
using AppAny.HotChocolate.FluentValidation;
using CityLibrary.Graphql.DataLoaders;
using CityLibrary.Graphql.Schemas.Mutations;
using CityLibrary.Graphql.Schemas.Queries;
using CityLibraryInfrastructure.ExceptionHandling;

namespace CityLibrary.Graphql.ServicesExtensions
{
    public static class ServicesExtensions
    {
        public static void AddRangeCustomServices(this IServiceCollection services, AppSetting appSetting)
        {
            services.AddCustomJwtService(appSetting.TokenOptions);
            services.AddHttpContextAccessor();

            services.AddDbContext<AppDbContext>(options =>
            {
                var triggerAssembly = Assembly.GetAssembly(typeof(AppDbContext));
                options.UseTriggers(triggerOptions => triggerOptions.AddAssemblyTriggers(triggerAssembly!));
                options.UseInMemoryDatabase(appSetting.DbConnectionString);
            });

            services.AddSingleton<ICustomMapper, MapsterMapping>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = appSetting.RedisConnection.ConnectionString;
                options.InstanceName = appSetting.RedisConnection.InstanceName;
            });

            services.AddScoped(typeof(IBaseRepo<TableBase, IConvertible>), typeof(BaseRepo<TableBase, IConvertible>));

            var assembliesToScan = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.GetAssembly(typeof(AppSetting)),
                Assembly.GetAssembly(typeof(AppDbContext)),
                Assembly.GetAssembly(typeof(MapsterMapping))
            };

            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
              .Where(c => c.Name.EndsWith("Repo"))
              .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
              .Where(c => c.Name.EndsWith("Service"))
              .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            // services.AddTransientServices(assembliesToScan);
        }

        // private static void AddTransientServices(this IServiceCollection services, Assembly[] assembliesToScan)
        // {
        //
        // }

        private static void AddCustomJwtService(this IServiceCollection services, TokenOptions tokenOptions)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
            {
                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = GetSymmetricSecurityKey(tokenOptions.SecurityKey),

                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddCustomLocalizationConfiguration(this IServiceCollection services)
        {
            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new ("en-GB"),
                    new ("tr-TR")
                };
                opt.DefaultRequestCulture = new RequestCulture("en-GB");
                opt.SupportedCultures = supportedCultures;
                opt.SupportedUICultures = supportedCultures;

                opt.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
            });
        }

        public static void AddGraphqlConfiguraiton(this IServiceCollection services, IWebHostEnvironment environment)
        { 
            const string fluentValidationCode = "FLUENT_VALIDATION_ERROR";
            services
                .AddGraphQLServer()
                .AddAuthorization()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<AuthQuery>()
                .AddType<BookReservationQuery>()
                .AddType<BookQuery>()
                .AddType<MemberQuery>()
                .AddType<MemberMutation>()
                .AddType<BookMutation>()
                .AddType<BookReservationMutation>()
                .AddFluentValidation(o =>
                {
                    o.UseErrorMapper((builder, context) =>
                    {
                        builder.SetMessage(context.ValidationFailure.ErrorMessage);
                        builder.SetExtension("property", context.ValidationFailure.PropertyName);
                        builder.SetExtension("value", context.ValidationFailure.AttemptedValue);
                    
                        builder.SetCode(fluentValidationCode);
                    });
                    // o.UseDefaultErrorMapperWithDetails();
                })
                .AddErrorFilter(error =>
                {
                    if (error.Exception is CustomException exception1)
                    {
                        IError returningEror = new Error(exception1.Message, "CUSTOM_EXCEPTION");

                        if (exception1.Serialized)
                        {
                            return returningEror.WithExtensions(new Dictionary<string, object>()
                            {
                                { "serialized", true }
                            });
                        }
                        else
                        {
                            return returningEror.WithExtensions(new Dictionary<string, object>()
                            {
                                { "serialized", false }
                            });
                        }
                    }
                    else if (error.Code is not fluentValidationCode)
                    {
                        if (environment.IsDevelopment())
                        {
                            IError returningEror = new Error(error.Message, "INTERNAL_SERVER_ERROR");
                            return returningEror.WithExtensions(new Dictionary<string, object>()
                            {
                                { "stackTrace", error.Exception?.StackTrace }
                            });
                        }
                        else
                        {
                            IError returningEror = new Error("INTERNAL_SERVER_ERROR", "INTERNAL_SERVER_ERROR");
                            return returningEror;
                        }
                    }

                    return error;
                });
            
            services.AddDataLoadersForGraphqlResolvers();
        }

        private static void AddDataLoadersForGraphqlResolvers(this IServiceCollection services)
        {
            services.AddScoped<BookLoader>();
            services.AddScoped<MemberLoader>();
        }
    }
}

