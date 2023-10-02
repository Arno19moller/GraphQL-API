using GraphQL_API.Context;
using GraphQL_API.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class InventoryDataService: IInventoryDataService
    {
        private readonly SakilaContext _dbContext;

        public InventoryDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Inventory> GetInventories(int numInventories, CancellationToken cancellationToken = default)
        {
            return _dbContext.Inventories
                 .Include(x => x.Film)
                 .Include(x => x.Rentals)
                 .Include(x => x.Store)
                 .AsNoTracking()
                 .Take(numInventories)
                 .ToList();
        }
    }
}
