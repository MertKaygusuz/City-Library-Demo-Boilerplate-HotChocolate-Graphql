using AppAny.HotChocolate.FluentValidation;
using CityLibraryApi.Dtos.Member;
using CityLibraryApi.Services.Member.Interfaces;
using HotChocolate.AspNetCore.Authorization;

namespace CityLibrary.Graphql.Schemas.Mutations;

[ExtendObjectType(typeof(Mutation))]
public class MemberMutation
{
    
    public async Task<string> Register([UseFluentValidation] RegistrationDto dto, [Service] IMemberService memberService)
    {
        return await memberService.RegisterAsync(dto);
    }
    
    [Authorize(Roles = new [] { "Admin" })]
    public async Task<bool> AdminUpdateMember([UseFluentValidation] RegistrationDto dto, [Service] IMemberService memberService)
    {
        await memberService.AdminUpdateMemberAsync(dto);
        return true;
    }
    
    [Authorize]
    public async Task<bool> MemberSelfUpdate([UseFluentValidation] MemberSelfUpdateDto dto, [Service] IMemberService memberService)
    {
        await memberService.MemberSelfUpdateAsync(dto);
        return true;
    }
    
}