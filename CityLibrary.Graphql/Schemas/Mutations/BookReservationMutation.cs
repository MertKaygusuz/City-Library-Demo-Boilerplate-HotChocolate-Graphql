using AppAny.HotChocolate.FluentValidation;
using CityLibraryApi.Dtos.BookReservation;
using CityLibraryApi.Services.BookReservation.Interfaces;
using HotChocolate.AspNetCore.Authorization;

namespace CityLibrary.Graphql.Schemas.Mutations;


[ExtendObjectType(typeof(Mutation))]
[Authorize(Roles = new [] { "Admin" })]
public class BookReservationMutation
{
    public async Task<bool> AssignBookToMember(
        [UseFluentValidation]AssignBookToMemberDto dto, 
        [Service] IBookReservationService bookReservationService)
    {
        await bookReservationService.AssignBookToMemberAsync(dto);
        return true;
    }
    
    public async Task<bool> UnAssignBookFromUser(
        [UseFluentValidation]AssignBookToMemberDto dto, 
        [Service] IBookReservationService bookReservationService)
    {
        await bookReservationService.UnAssignBookFromUserAsync(dto);
        return true;
    }
}