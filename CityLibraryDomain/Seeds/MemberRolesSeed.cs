using CityLibraryInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibraryDomain.Seeds
{
    class MemberRolesSeed : IEntityTypeConfiguration<MemberRoles>
    {
        public void Configure(EntityTypeBuilder<MemberRoles> builder)
        {
            builder.HasData(GetSeedData());
        }

        private static MemberRoles[] GetSeedData()
        {
            var memberRoles = new MemberRoles[12];
            
            memberRoles[0] = new MemberRoles
            {
                Id = 1,
                RoleId = 1,
                MemberId = "Admin",
                CreatedAt = DateTime.Now
            };
            memberRoles[1] = new MemberRoles
            {
                Id = 2,
                RoleId = 2,
                MemberId = "Admin",
                CreatedAt = DateTime.Now
            };
            int id = 2;
            for (int i = 1; i <= 10; i++)
            {
                memberRoles[id] = new MemberRoles()
                {
                    Id = id + 1,
                    RoleId = 2,
                    MemberId = $"User{i}",
                    CreatedAt = DateTime.Now
                };
                id++;
            }

            return memberRoles;
        }
    }
}
