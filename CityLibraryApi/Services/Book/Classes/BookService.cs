﻿using CityLibraryApi.Dtos.Book;
using CityLibraryApi.Services.Book.Interfaces;
using CityLibraryDomain.UnitOfWorks;
using CityLibraryInfrastructure.Entities;
using CityLibraryInfrastructure.MapperConfigurations;
using CityLibraryInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibraryApi.Services.Book.Classes
{
    public class BookService : IBookService
    {
        private readonly IBooksRepo _booksRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _mapper;
        public BookService(IBooksRepo booksRepo, IUnitOfWork unitOfWork, ICustomMapper customMapper)
        {
            _booksRepo = booksRepo;
            _unitOfWork = unitOfWork;
            _mapper = customMapper;
        }
        public async Task<int> BookRegisterAsync(RegisterBookDto dto)
        {
            var bookToAdd = _mapper.Map<RegisterBookDto, Books>(dto);
            await _booksRepo.InsertAsync(bookToAdd);
            await _unitOfWork.CommitAsync();
            return bookToAdd.BookId;
        }

        public async Task DeleteBookAsync(DeleteBookDto dto)
        {
            await _booksRepo.DeleteByIdAsync(dto.BookId);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DoesEntityExistAsync(IConvertible Id)
        {
            return await _booksRepo.DoesEntityExistAsync((int)Id);
        }

        public IQueryable<BookResponseDto> GetAllBooks()
        {
            return _mapper.MapAsQueryable<Books, BookResponseDto>(_booksRepo.GetData());
        }

        public async Task<IReadOnlyDictionary<int, BookLoaderDto>> GetManyBooksByIds(IEnumerable<int> bookIds)
        {
            return await _booksRepo.GetData()
                            .Where(x => bookIds.Contains(x.BookId))
                            .Select(x => new BookLoaderDto()
                            {
                                BookId = x.BookId,
                                Author = x.Author,
                                BookTitle = x.BookTitle,
                                FirstPublishDate = x.FirstPublishDate,
                                EditionNumber = x.EditionNumber,
                                EditionDate = x.EditionDate,
                                TitleType = x.TitleType,
                                CoverType = x.CoverType,
                                AvailableCount = x.AvailableCount,
                                ReservedCount = x.ReservedCount
                            })
                            .ToDictionaryAsync(x => x.BookId);
        }

        public async Task<int> GetNumberOfAuthorsFromBookTableAsync()
        {
            return await _booksRepo.GetData().Select(x => x.Author).Distinct().CountAsync();
        }

        public async Task<int> GetNumberOfDistinctTitleAsync()
        {
            return await _booksRepo.GetData().Select(x => x.BookTitle).Distinct().CountAsync();
        }

        public async Task UpdateBookInfoAsync(UpdateBookDto dto)
        {
            var existingBook = await _booksRepo.GetByIdAsync(dto.BookId);
            _mapper.MapToExistingObject(dto, existingBook);
            await _unitOfWork.CommitAsync();
        }
    }
}
