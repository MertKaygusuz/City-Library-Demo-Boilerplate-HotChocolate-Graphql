using AppAny.HotChocolate.FluentValidation;
using CityLibraryApi.Dtos.Authentication;
using CityLibraryApi.Dtos.Authentication.Validators;
using CityLibraryApi.Dtos.Token.Records;
using CityLibraryApi.Services.Token.Interfaces;

namespace CityLibrary.Graphql.Schemas.Queries;

[ExtendObjectType(typeof(Query))]
public class AuthQuery
{
    
    public async Task<ReturnTokenRecord> Login(
        [UseFluentValidation/*, UseValidator<LoginDtoValidator>*/]LoginDto dto,
        [Service] IAuthenticationService authenticationService)
    {
        return await authenticationService.LoginAsync(dto);
    }
    
    public async Task<bool> Logout(
        string refreshToken,
        [Service] IAuthenticationService authenticationService)
    {
        await authenticationService.LogoutAsync(refreshToken);
        return true;
    }
    
    public async Task<ReturnTokenRecord> ReLoginWithRefreshToken(
        string refreshToken,
        [Service] IAuthenticationService authenticationService)
    {
        return await authenticationService.RefreshLoginTokenAsync(refreshToken);
    }
    
}