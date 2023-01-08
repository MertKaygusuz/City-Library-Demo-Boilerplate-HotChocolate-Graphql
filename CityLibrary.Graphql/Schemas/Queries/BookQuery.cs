using CityLibraryApi.Dtos.Book;
using CityLibraryApi.Services.Book.Interfaces;
using HotChocolate.AspNetCore.Authorization;

namespace CityLibrary.Graphql.Schemas.Queries;

[ExtendObjectType(typeof(Query))]
public class BookQuery
{
    public async Task<int> GetNumberOfDistinctTitleAsync([Service] IBookService bookService)
    {
        return await bookService.GetNumberOfDistinctTitleAsync();
    }
    
    public async Task<int> GetNumberOfAuthorsFromBookTableAsync([Service] IBookService bookService)
    {
        return await bookService.GetNumberOfAuthorsFromBookTableAsync();
    }
    
    [Authorize(Roles = new [] { "Admin" })]
    [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 5, MaxPageSize = 10), UseProjection, UseFiltering, UseSorting]
    public IQueryable<BookResponseDto> GetAllBooks([Service(ServiceKind.Resolver)] IBookService bookService)
    {
        return bookService.GetAllBooks();
    }
}