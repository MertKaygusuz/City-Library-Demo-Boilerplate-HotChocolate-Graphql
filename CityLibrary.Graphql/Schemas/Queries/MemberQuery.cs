using CityLibraryApi.Dtos.Member;
using CityLibraryApi.Services.Member.Interfaces;
using HotChocolate.AspNetCore.Authorization;

namespace CityLibrary.Graphql.Schemas.Queries;

[ExtendObjectType(typeof(Query))]
public class MemberQuery
{
    [Authorize(Roles = new [] { "Admin" })]
    [UsePaging(IncludeTotalCount = true, DefaultPageSize = 3, MaxPageSize = 10), UseProjection, UseFiltering, UseSorting]
    public IQueryable<MemberResponseDto> GetAllMembers([Service] IMemberService memberService)
    {
        return memberService.GetAllMembers();
    }
}