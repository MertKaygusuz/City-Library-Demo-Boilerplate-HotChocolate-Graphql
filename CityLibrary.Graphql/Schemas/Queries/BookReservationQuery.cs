using AppAny.HotChocolate.FluentValidation;
using CityLibrary.Graphql.Schemas.Types;
using CityLibraryApi.Dtos.BookReservation;
using CityLibraryApi.Services.BookReservation.Interfaces;
using HotChocolate.Authorization;

namespace CityLibrary.Graphql.Schemas.Queries;

[ExtendObjectType(typeof(Query))]
public class BookReservationQuery
{
    [Authorize(Roles = new [] { "Admin" })]
    [UsePaging(IncludeTotalCount = true, DefaultPageSize = 3, MaxPageSize = 10), UseProjection, UseFiltering, UseSorting]
    public IQueryable<ActiveBookReservationResolverType> GetAllActiveBookReservations([Service(ServiceKind.Resolver)] IBookReservationService reservationService)
    {
        return reservationService.GetAllActiveBookReservations().Select(x => new ActiveBookReservationResolverType()
        {
            ReservationId = x.ReservationId,
            ReturnDate = x.ReturnDate,
            MemberId = x.MemberId,
            BookId = x.BookId
        });
    }
    
    [Authorize(Roles = new [] { "Admin" })]
    [UsePaging(IncludeTotalCount = true, DefaultPageSize = 3, MaxPageSize = 10), UseProjection, UseFiltering, UseSorting]
    public IQueryable<BookReservationHistoriesResolverType> GetReservationHistoryByMember(
        [UseFluentValidation] ReservationHistoryMemberDto dto,
        [Service(ServiceKind.Resolver)] IBookReservationService reservationService)
    {
        return reservationService.GetReservationHistoryByMember(dto).Select(x =>
            new BookReservationHistoriesResolverType()
            {
                HistoryId = x.HistoryId,
                ReturnDate = x.ReturnDate,
                RecievedDate = x.RecievedDate,
                MemberId = x.MemberId,
                BookId = x.BookId
            });
    }
    
    [Authorize(Roles = new [] { "Admin" })]
    [UsePaging(IncludeTotalCount = true, DefaultPageSize = 3, MaxPageSize = 10), UseProjection, UseFiltering, UseSorting]
    public IQueryable<BookReservationHistoriesResolverType> GetReservationHistoryByBook(
        [UseFluentValidation] ReservationHistoryBookDto dto,
        [Service(ServiceKind.Resolver)] IBookReservationService reservationService)
    {
        return reservationService.GetReservationHistoryByBook(dto).Select(x =>
            new BookReservationHistoriesResolverType()
            {
                HistoryId = x.HistoryId,
                ReturnDate = x.ReturnDate,
                RecievedDate = x.RecievedDate,
                MemberId = x.MemberId,
                BookId = x.BookId
            });
    }
    
    [UsePaging(IncludeTotalCount = true, DefaultPageSize = 3, MaxPageSize = 10), UseProjection, UseFiltering, UseSorting]
    public IQueryable<NumberOfBooksPerTitleAndEditionNumberResponseDto> GetNumberOfBooksPerTitleAndEditionNumber([Service(ServiceKind.Resolver)] IBookReservationService reservationService)
    {
        return reservationService.GetNumberOfBooksPerTitleAndEditionNumber();
    }
    
    [Authorize(Roles = new [] { "Admin" })]
    [UsePaging(IncludeTotalCount = true, DefaultPageSize = 3, MaxPageSize = 10), UseProjection, UseFiltering, UseSorting]
    public IQueryable<NumberOfBooksReservedByMembersResponseDto> GetNumberOfBooksReservedPerMembers([Service(ServiceKind.Resolver)] IBookReservationService reservationService)
    {
        return reservationService.GetNumberOfBooksReservedPerMembers();
    }
    
    public IEnumerable<DateTime> GetReservedBooksEstimatedReturnDates(
        [UseFluentValidation] ReservedBookEstimatedReturnDatesDto dto,
        [Service] IBookReservationService reservationService)
    {
        return reservationService.GetReservedBooksEstimatedReturnDates(dto);
    }
}