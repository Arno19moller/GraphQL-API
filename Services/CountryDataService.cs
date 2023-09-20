using GraphQL.Data;
using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public class CountryDataService : ICountryDataService
    {
        private readonly SakilaContext _dbContext;

        public CountryDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Country> GetCountries(int numCountries, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
