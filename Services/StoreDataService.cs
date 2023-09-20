using GraphQL.Data;
using GraphQL.Entities;

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
            throw new NotImplementedException();
        }
    }
}
