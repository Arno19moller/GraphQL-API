using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class InventoryDataService: IInventoryDataService
    {
        private readonly SakilaContext _dbContext;

        public InventoryDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
