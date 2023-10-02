using GraphQL_API.Context;
using GraphQL_API.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class CityDataService : ICityDataService
    {
        private readonly SakilaContext _dbContext;

        public CityDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CityType> GetCities(int numCities, CancellationToken cancellationToken = default)
        {
            return _dbContext.Cities.Include(x => x.Addresses)
                .Include(x => x.Country)
                .AsNoTracking()
                .Take(numCities)
                .ToList();
        }
    }
}
