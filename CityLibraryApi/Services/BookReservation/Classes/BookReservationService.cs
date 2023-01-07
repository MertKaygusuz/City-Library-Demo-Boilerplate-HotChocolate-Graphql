using CityLibraryApi.Dtos.BookReservation;
using CityLibraryApi.Services.BookReservation.Interfaces;
using CityLibraryDomain.UnitOfWorks;
using CityLibraryInfrastructure.Entities;
using CityLibraryInfrastructure.ExceptionHandling;
using CityLibraryInfrastructure.Extensions;
using CityLibraryInfrastructure.MapperConfigurations;
using CityLibraryInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CityLibraryInfrastructure.ExceptionHandling.Dtos;
using CityLibraryInfrastructure.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CityLibraryApi.Services.BookReservation.Classes
{
    public class BookReservationService : IBookReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<ExceptionsResource> _localizer;
        private readonly IActiveBookReservationsRepo _activeBookReservationsRepo;
        private readonly IBookReservationHistoriesRepo _bookReservationHistoriesRepo;
        private readonly IMembersRepo _membersRepo;
        private readonly IBooksRepo _booksRepo;
        public BookReservationService(
            IUnitOfWork unitOfWork,
            IStringLocalizer<ExceptionsResource> localizer,
            IActiveBookReservationsRepo activeBookReservationsRepo,
            IBookReservationHistoriesRepo bookReservationHistoriesRepo,
            IMembersRepo membersRepo,
            IBooksRepo booksRepo)
        {
            _unitOfWork = unitOfWork;
            _activeBookReservationsRepo = activeBookReservationsRepo;
            _bookReservationHistoriesRepo = bookReservationHistoriesRepo;
            _membersRepo = membersRepo;
            _booksRepo = booksRepo;
            _localizer = localizer;
        }

        public async Task AssignBookToMemberAsync(AssignBookToMemberDto dto)
        {
            #region existence check
            var memberExistanceTask = _membersRepo.DoesEntityExistAsync(dto.UserName);
            var bookTask = _booksRepo.GetByIdAsync(dto.BookId);
            await Task.WhenAll(memberExistanceTask, bookTask);
            var memberExist = memberExistanceTask.Result;
            var theBook = bookTask.Result;
            
            if (!(memberExist && theBook is not null))
            {
                var err = new ErrorDto();
                if (!memberExist)
                    err.Errors.Add(nameof(dto.UserName), new List<string>() { _localizer["User_Name_Not_Exist"] });

                if(theBook is null)
                    err.Errors.Add(nameof(dto.BookId), new List<string>() { _localizer["Book_Not_Exist"] });

                throw new CustomException(JsonSerializer.Serialize(err), true);
            }
            
            bool isThereAnyAvailableBook = await CheckIfAnyAvailableBooksAsync(dto.BookId);

            if(isThereAnyAvailableBook is false)
            {
                var err = new ErrorDto();
                err.Errors.Add(nameof(dto.BookId), new List<string>() { _localizer["Book_Not_Available"] });
                throw new CustomException(JsonSerializer.Serialize(err), true);
            }
            #endregion
            

            theBook.AvailableCount -= 1;
            theBook.ReservedCount += 1;
            ActiveBookReservations reservation = new()
            {
                BookId = dto.BookId,
                MemberId = dto.UserName,
                ReturnDate = DateTime.Now
            };

            await _activeBookReservationsRepo.InsertAsync(reservation);

            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> CheckIfAnyAvailableBooksAsync(int bookId)
        {
            short availableBookCount = await _booksRepo.GetDataWithLinqExp(x => x.BookId == bookId)
                                                    .Select(x => x.AvailableCount)
                                                    .SingleOrDefaultAsync();

            return availableBookCount > 0;
        }

        public async Task<bool> CheckIfBookExistsAsync(int bookId)
        {
            return await _booksRepo.DoesEntityExistAsync(bookId);
        }

        public IQueryable<ActiveBookReservations> GetAllActiveBookReservations()
        {
            return _activeBookReservationsRepo.GetData();
            
        }

        public IQueryable<NumberOfBooksPerTitleAndEditionNumberResponseDto> GetNumberOfBooksPerTitleAndEditionNumber()
        {
            return _booksRepo.GetData()
                .GroupBy(x => new { x.BookTitle, x.EditionNumber })
                .Select(x => new NumberOfBooksPerTitleAndEditionNumberResponseDto
                {
                    BookTitle = x.Key.BookTitle,
                    EditionNumber = x.Key.EditionNumber,
                    Count = x.Sum(y => y.AvailableCount)
                });
        }

        public IQueryable<NumberOfBooksReservedByMembersResponseDto> GetNumberOfBooksReservedPerMembers()
        {

            return _activeBookReservationsRepo.GetData()
                .Select(x => new
                {
                    x.MemberId,
                    x.Member.FullName
                })
                .GroupBy(x => new { x.MemberId, x.FullName })
                .Select(x => new NumberOfBooksReservedByMembersResponseDto
                {
                    MemberName = x.Key.MemberId,
                    MemberFullName = x.Key.FullName,
                    ActiveBookReservationsCount = x.Count()
                });
        }

        public IQueryable<BookReservationHistories> GetReservationHistoryByBook(ReservationHistoryBookDto dto)
        {
            return _bookReservationHistoriesRepo.GetData().Where(x => x.BookId == dto.BookId);
        }

        public IQueryable<BookReservationHistories> GetReservationHistoryByMember(ReservationHistoryMemberDto dto)
        {
            return _bookReservationHistoriesRepo.GetData().Where(x => x.MemberId == dto.UserName);
        }
        

        public IEnumerable<DateTime> GetReservedBooksEstimatedReturnDates(ReservedBookEstimatedReturnDatesDto dto)
        {
            var result = _activeBookReservationsRepo.GetDataWithLinqExp(x => x.BookId == dto.BookId)
                                                                                .AsEnumerable()
                                                                                .Select(x => x.AvailableAt)
                                                                                .Order();
                                                          
            if (!result.Any())
                throw new CustomException(_localizer["No_Reservation_On_Search"]);

            return result;
        }

        public async Task UnAssignBookFromUserAsync(AssignBookToMemberDto dto)
        {
            #region existence check
            var memberExistanceTask = _membersRepo.DoesEntityExistAsync(dto.UserName);
            var bookTask = _booksRepo.GetByIdAsync(dto.BookId);
            await Task.WhenAll(memberExistanceTask, bookTask);
            var memberExist = memberExistanceTask.Result;
            var bookRecord = bookTask.Result;
            
            if (!(memberExist && bookRecord is not null))
            {
                var err = new ErrorDto();
                if (!memberExist)
                    err.Errors.Add(nameof(dto.UserName), new List<string>() { _localizer["User_Name_Not_Exist"] });

                if(bookRecord is null)
                    err.Errors.Add(nameof(dto.BookId), new List<string>() { _localizer["Book_Not_Exist"] });

                throw new CustomException(JsonSerializer.Serialize(err), true);
            }
            #endregion

            #region active reservation check
            //get first record on the basis of ReturnDate
            var activeReservation = await _activeBookReservationsRepo.GetDataWithLinqExp(x => x.MemberId == dto.UserName
                    && x.BookId == dto.BookId)
                .OrderBy(x => x.ReturnDate)
                .FirstOrDefaultAsync();

            if (activeReservation is null)
                throw new CustomException(_localizer["Active_Book_Reservation_Not_Found"]);
            #endregion
            
            
            bookRecord.ReservedCount -= 1;
            bookRecord.AvailableCount += 1;

            var historyRecord = new BookReservationHistories()
            {
                BookId = dto.BookId,
                MemberId = dto.UserName,
                ReturnDate = activeReservation.ReturnDate,
                RecievedDate = DateTime.Now
            };
            await _bookReservationHistoriesRepo.InsertAsync(historyRecord);
            _activeBookReservationsRepo.Delete(activeReservation);
            await _unitOfWork.CommitAsync();
        }
    }
}
