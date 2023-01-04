using CityLibraryApi.Dtos.BookReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityLibraryInfrastructure.Entities;

namespace CityLibraryApi.Services.BookReservation.Interfaces
{
    public interface IBookReservationService
    {
        IQueryable<NumberOfBooksPerTitleAndEditionNumberResponseDto> GetNumberOfBooksPerTitleAndEditionNumber();

        IQueryable<NumberOfBooksReservedByMembersResponseDto> GetNumberOfBooksReservedPerMembers();

        IQueryable<ActiveBookReservations> GetAllActiveBookReservations();

        IQueryable<BookReservationHistories> GetReservationHistoryByMember(ReservationHistoryMemberDto dto);

        IQueryable<BookReservationHistories> GetReservationHistoryByBook(ReservationHistoryBookDto dto);
        /// <summary>
        /// Searches estimated return dates of any reserved book.
        /// </summary>
        /// <param name="dto">Includes book id.</param>
        /// <returns>Estimated return dates respectively.</returns>
        IEnumerable<DateTime> GetReservedBooksEstimatedReturnDates(ReservedBookEstimatedReturnDatesDto dto);

        /// <summary>
        /// Inserts data to active book reservations
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AssignBookToMemberAsync(AssignBookToMemberDto dto);

        /// <summary>
        /// Soft delete from active book reservations and insert data to book reservation history
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UnAssignBookFromUserAsync(AssignBookToMemberDto dto); //uses same dto

        Task<bool> CheckIfMemberExistsAsync(string UserName);

        Task<bool> CheckIfBookExistsAsync(int bookId);

        Task<bool> CheckIfAnyAvailableBooksAsync(int bookId);
    }
}
