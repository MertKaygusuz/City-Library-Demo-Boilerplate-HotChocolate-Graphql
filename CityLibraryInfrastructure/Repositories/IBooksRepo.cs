using System.Linq.Expressions;
using CityLibraryInfrastructure.DbBase;
using CityLibraryInfrastructure.Entities;

namespace CityLibraryInfrastructure.Repositories
{
    public interface IBooksRepo : IBaseRepo<Books, int>
    {
        public Task<int> BulkSoftDeleteAsync(Expression<Func<Books, bool>> whereClause, string deletedBy);
    }
}
