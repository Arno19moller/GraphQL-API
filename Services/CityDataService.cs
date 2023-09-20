using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class CityDataService : ICityDataService
    {
        private readonly SakilaContext _dbContext;

        public CityDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
