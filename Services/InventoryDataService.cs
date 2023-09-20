using GraphQL.Data;
using GraphQL.Entities;

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
            throw new NotImplementedException();
        }
    }
}
