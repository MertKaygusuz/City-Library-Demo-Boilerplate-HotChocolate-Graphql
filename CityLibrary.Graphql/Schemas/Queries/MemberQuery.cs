using CityLibraryApi.Dtos.Member;
using CityLibraryApi.Services.Member.Interfaces;
using HotChocolate.Authorization;

namespace CityLibrary.Graphql.Schemas.Queries;

[ExtendObjectType(typeof(Query))]
public class MemberQuery
{
    [Authorize(Roles = new [] { "Admin" })]
    [UsePaging(IncludeTotalCount = true, DefaultPageSize = 3, MaxPageSize = 10), UseProjection, UseFiltering, UseSorting]
    public IQueryable<MemberResponseDto> GetAllMembers([Service(ServiceKind.Resolver)] IMemberService memberService)
    {
        return memberService.GetAllMembers();
    }
}