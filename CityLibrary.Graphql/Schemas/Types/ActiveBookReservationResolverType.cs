using CityLibrary.Graphql.DataLoaders;
using CityLibraryApi.Dtos.Book;
using CityLibraryApi.Dtos.Member;

namespace CityLibrary.Graphql.Schemas.Types;

public class ActiveBookReservationResolverType
{
    public int ReservationId { get; set; }

    public DateTime ReturnDate { get; set; }

    //Default return period 7 days
    public DateTime AvailableAt => ReturnDate.AddDays(7);

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