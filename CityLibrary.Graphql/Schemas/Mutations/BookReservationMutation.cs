using AppAny.HotChocolate.FluentValidation;
using CityLibraryApi.Dtos.BookReservation;
using CityLibraryApi.Services.BookReservation.Interfaces;
using HotChocolate.Authorization;

namespace CityLibrary.Graphql.Schemas.Mutations;


[ExtendObjectType(typeof(Mutation))]
public class BookReservationMutation
{
    [Authorize(Roles = new [] { "Admin" })]
    public async Task<bool> AssignBookToMember(
        [UseFluentValidation]AssignBookToMemberDto dto, 
        [Service] IBookReservationService bookReservationService)
    {
        await bookReservationService.AssignBookToMemberAsync(dto);
        return true;
    }
    
    [Authorize(Roles = new [] { "Admin" })]
    public async Task<bool> UnAssignBookFromUser(
        [UseFluentValidation]AssignBookToMemberDto dto, 
        [Service] IBookReservationService bookReservationService)
    {
        await bookReservationService.UnAssignBookFromUserAsync(dto);
        return true;
    }
}