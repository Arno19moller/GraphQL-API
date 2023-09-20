using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class StoreDataService: IStoreDataService
    {
        private readonly SakilaContext _dbContext;

        public StoreDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
