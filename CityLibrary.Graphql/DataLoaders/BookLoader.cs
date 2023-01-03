using CityLibraryApi.Dtos.Book;
using CityLibraryApi.Services.Book.Interfaces;

namespace CityLibrary.Graphql.DataLoaders;

public class BookLoader: BatchDataLoader<int, BookLoaderDto>
{
    public BookLoader(
        IBookService bookService,
        IBatchScheduler batchScheduler, 
        DataLoaderOptions options = null) : base(batchScheduler, options)
    {
        _bookService = bookService;
    }
    
    private readonly IBookService _bookService;

    protected override Task<IReadOnlyDictionary<int, BookLoaderDto>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        return _bookService.GetManyBooksByIds(keys);
    }
}