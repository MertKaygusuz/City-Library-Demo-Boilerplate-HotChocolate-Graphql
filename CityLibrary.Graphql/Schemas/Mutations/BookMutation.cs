using AppAny.HotChocolate.FluentValidation;
using CityLibraryApi.Dtos.Book;
using CityLibraryApi.Services.Book.Interfaces;
using HotChocolate.AspNetCore.Authorization;

namespace CityLibrary.Graphql.Schemas.Mutations;

[ExtendObjectType(typeof(Mutation))]
[Authorize(Roles = new [] { "Admin" })]
public class BookMutation
{
    public async Task<int> BookRegister([UseFluentValidation]RegisterBookDto dto, [Service] IBookService bookService)
    {
        return await bookService.BookRegisterAsync(dto);
    }
    
    public async Task<bool> BookInfoUpdate([UseFluentValidation]UpdateBookDto dto, [Service] IBookService bookService)
    {
        await bookService.UpdateBookInfoAsync(dto);
        return true;
    }
    
    public async Task<bool> DeleteBook([UseFluentValidation]DeleteBookDto dto, [Service] IBookService bookService)
    {
        await bookService.DeleteBookAsync(dto);
        return true;
    }
}