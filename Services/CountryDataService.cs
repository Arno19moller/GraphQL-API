using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class CountryDataService : ICountryDataService
    {
        private readonly SakilaContext _dbContext;

        public CountryDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
