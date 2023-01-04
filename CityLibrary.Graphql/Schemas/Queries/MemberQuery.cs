using CityLibraryApi.Dtos.Member;
using CityLibraryApi.Services.Member.Interfaces;
using HotChocolate.AspNetCore.Authorization;

namespace CityLibrary.Graphql.Schemas.Queries;

[ExtendObjectType(typeof(Query))]
public class MemberQuery
{
    [Authorize(Roles = new [] { "Admin" })]
    public IQueryable<MemberResponseDto> GetAllMembers([Service] IMemberService memberService)
    {
        return memberService.GetAllMembers();
    }
}