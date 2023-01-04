using AppAny.HotChocolate.FluentValidation;
using CityLibrary.Graphql.Schemas.Types;
using CityLibraryApi.Dtos.BookReservation;
using CityLibraryApi.Services.BookReservation.Interfaces;
using HotChocolate.AspNetCore.Authorization;

namespace CityLibrary.Graphql.Schemas.Queries;

[ExtendObjectType(typeof(Query))]
public class BookReservationQuery
{
    public IQueryable<ActiveBookReservationResolverType> GetAllActiveBookReservations([Service] IBookReservationService reservationService)
    {
        return reservationService.GetAllActiveBookReservations().Select(x => new ActiveBookReservationResolverType()
        {
            ReservationId = x.ReservationId,
            ReturnDate = x.ReturnDate,
            MemberId = x.MemberId,
            BookId = x.BookId
        });
    }
    
    public IQueryable<BookReservationHistoriesResolverType> GetReservationHistoryByMember(
        [UseFluentValidation] ReservationHistoryMemberDto dto,
        [Service] IBookReservationService reservationService)
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
    
    public IQueryable<BookReservationHistoriesResolverType> GetReservationHistoryByBook(
        [UseFluentValidation] ReservationHistoryBookDto dto,
        [Service] IBookReservationService reservationService)
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

    public IQueryable<NumberOfBooksPerTitleAndEditionNumberResponseDto> GetNumberOfBooksPerTitleAndEditionNumber([Service] IBookReservationService reservationService)
    {
        return reservationService.GetNumberOfBooksPerTitleAndEditionNumber();
    }
    
    public IQueryable<NumberOfBooksReservedByMembersResponseDto> GetNumberOfBooksReservedPerMembers([Service] IBookReservationService reservationService)
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