using CityLibraryDomain.ContextRelated;
using CityLibraryDomain.DbBase.Repositories.Base;
using CityLibraryInfrastructure.Entities;
using CityLibraryInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace CityLibraryDomain.Repositories
{
    public class BooksRepo : BaseRepo<Books, int>, IBooksRepo
    {
        public BooksRepo(AppDbContext dbContext) : base(dbContext)
        {

        }
        

        public async Task<int> BulkSoftDeleteAsync(Expression<Func<Books, bool>> whereClause, string deletedBy)
        {
            return await GetData()
                            .Where(whereClause)
                            .ExecuteUpdateAsync(s => s.SetProperty(x => x.DeletedAt, DateTime.Now)
                                .SetProperty(x => x.DeletedBy, deletedBy)
                            );
        }
    }
}
