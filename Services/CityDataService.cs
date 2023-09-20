using GraphQL.Data;
using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public class CityDataService : ICityDataService
    {
        private readonly SakilaContext _dbContext;

        public CityDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<City> GetCities(int numCities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
