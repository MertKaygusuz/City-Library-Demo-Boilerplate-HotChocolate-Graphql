using CityLibraryInfrastructure.Entities;
using CityLibraryInfrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibraryDomain.Seeds
{
    class MembersSeed : IEntityTypeConfiguration<Members>
    {
        public void Configure(EntityTypeBuilder<Members> builder)
        {
            string sharedPassword = "1234567890";
            sharedPassword.CreatePasswordHash(out string hashedPass);
            var members = new Members[]
            {
                new Members
                {
                     UserName = "Admin",
                     FullName = "Admin",
                     BirthDate = DateTime.Now.AddYears(-30),
                     Address = "Admin's Address",
                     Password = hashedPass,
                     CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Members
                {
                     UserName = "User1",
                     FullName = "Orhan",
                     BirthDate = DateTime.Now.AddYears(-30),
                     Address = "Orhan's Address",
                     Password = hashedPass,
                     CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Members
                {
                    UserName = "User2",
                    FullName = "Kaya",
                    BirthDate = DateTime.Now.AddYears(-40),
                    Address = "Kaya's Address",
                    Password = hashedPass,
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Members
                {
                    UserName = "User3",
                    FullName = "Kadriye",
                    BirthDate = DateTime.Now.AddYears(-20),
                    Address = "Kadriye's Address",
                    Password = hashedPass,
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Members
                {
                    UserName = "User4",
                    FullName = "Zuşer",
                    BirthDate = DateTime.Now.AddYears(-30),
                    Address = "Zuşer's Address",
                    Password = hashedPass,
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Members
                {
                    UserName = "User5",
                    FullName = "Devran",
                    BirthDate = DateTime.Now.AddYears(-22),
                    Address = "Devran's Address",
                    Password = hashedPass,
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Members
                {
                    UserName = "User6",
                    FullName = "Viladimir",
                    BirthDate = DateTime.Now.AddYears(-55),
                    Address = "Viladimir's Address",
                    Password = hashedPass,
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Members
                {
                    UserName = "User7",
                    FullName = "Fidel",
                    BirthDate = DateTime.Now.AddYears(-89),
                    Address = "Fidel's Address",
                    Password = hashedPass,
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Members
                {
                    UserName = "User8",
                    FullName = "Hasan",
                    BirthDate = DateTime.Now.AddYears(-60),
                    Address = "Hasan's Address",
                    Password = hashedPass,
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Members
                {
                    UserName = "User9",
                    FullName = "Behice",
                    BirthDate = DateTime.Now.AddYears(-60),
                    Address = "Behice's Address",
                    Password = hashedPass,
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                new Members
                {
                    UserName = "User10",
                    FullName = "Clara",
                    BirthDate = DateTime.Now.AddYears(-70),
                    Address = "Clara's Address",
                    Password = hashedPass,
                    CreatedAt = DateTime.Now.AddYears(-1)
                }
            };

            builder.HasData(members);
        }
    }
}
