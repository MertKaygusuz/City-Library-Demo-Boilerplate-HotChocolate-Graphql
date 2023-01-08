using CityLibraryApi.Dtos.Book;
using CityLibraryInfrastructure.BaseInterfaces;
using CityLibraryInfrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibraryApi.Services.Book.Interfaces
{
    public interface IBookService : IBaseCheckService
    {
        /// <summary>
        /// Save new books
        /// </summary>
        /// <param name="dto">Registration parameters</param>
        /// <returns>Book id</returns>
        Task<int> BookRegisterAsync(RegisterBookDto dto);

        /// <summary>
        /// Update book's information of existing book
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateBookInfoAsync(UpdateBookDto dto);

        Task<int> GetNumberOfDistinctTitleAsync();

        Task<int> GetNumberOfAuthorsFromBookTableAsync();

        IQueryable<BookResponseDto> GetAllBooks();
        
        /// <summary>
        /// Use for graphql resolving book field batch loading.
        /// </summary>
        /// <param name="bookIds">Book ids to get data</param>
        /// <returns></returns>
        Task<IReadOnlyDictionary<int, BookLoaderDto>> GetManyBooksByIds(IEnumerable<int> bookIds);

        Task DeleteByIdWithBuilDelete(DeleteBookDto dto);
    }
}
