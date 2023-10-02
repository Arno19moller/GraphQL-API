using GraphQL_API.Context;
using GraphQL_API.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class CountryDataService : ICountryDataService
    {
        private readonly SakilaContext _dbContext;

        public CountryDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CountryType> GetCountries(int numCountries, CancellationToken cancellationToken = default)
        {
            return _dbContext.Countries.Include(x => x.Cities)
                 .AsNoTracking()
                 .Take(numCountries)
                 .ToList();
        }
    }
}
