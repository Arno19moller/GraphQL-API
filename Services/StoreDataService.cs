using GraphQL.Data;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class StoreDataService: IStoreDataService
    {
        private readonly SakilaContext _dbContext;

        public StoreDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Store> GetStores(int numStores, CancellationToken cancellationToken = default)
        {
            return _dbContext.Stores
                .Include(x => x.Address)
                .Include(x => x.Customers)
                .Include(x => x.Inventories)
                .Include(x => x.Staff)
                .Include(x => x.ManagerStaff)
                .AsNoTracking()
                .Take(numStores)
                .ToList();
        }
    }
}
