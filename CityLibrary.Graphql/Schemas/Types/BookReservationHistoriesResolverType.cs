using CityLibrary.Graphql.DataLoaders;
using CityLibraryApi.Dtos.Book;
using CityLibraryApi.Dtos.Member;
using CityLibraryInfrastructure.Entities;

namespace CityLibrary.Graphql.Schemas.Types;

public class BookReservationHistoriesResolverType
{
    public int HistoryId { get; set; }

    public DateTime ReturnDate { get; set; }

    public DateTime RecievedDate { get; set; }

    [IsProjected(true)]
    public string MemberId { get; set; }

    [IsProjected(true)]
    public int BookId { get; set; }
    
    [GraphQLNonNullType]
    public async Task<MemberLoaderDto> Member([Service] MemberLoader memberLoader)
    {
        return await memberLoader.LoadAsync(MemberId, CancellationToken.None);
    }
    
    [GraphQLNonNullType]
    public async Task<BookLoaderDto> Book([Service] BookLoader bookLoader)
    {
        return await bookLoader.LoadAsync(BookId, CancellationToken.None);
    }
}