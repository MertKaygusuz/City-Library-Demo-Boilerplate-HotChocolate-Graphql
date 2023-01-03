using CityLibraryApi.Dtos.Member;
using CityLibraryApi.Services.Member.Interfaces;

namespace CityLibrary.Graphql.DataLoaders;

public class MemberLoader : BatchDataLoader<string, MemberLoaderDto>
{
    public MemberLoader(
        IMemberService memberService,
        IBatchScheduler batchScheduler, 
        DataLoaderOptions options = null) : base(batchScheduler, options)
    {
        _memberService = memberService;
    }
    
    private readonly IMemberService _memberService;

    protected override Task<IReadOnlyDictionary<string, MemberLoaderDto>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
    {
        return _memberService.GetManyMembersByUserNames(keys);
    }
}