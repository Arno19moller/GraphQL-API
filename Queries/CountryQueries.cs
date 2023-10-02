using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class CountryQueries
	{
        public async Task<List<CountryType>> GetCountryData(int numCountries, [Service] ICountryDataService countryService, CancellationToken cancellationToken)
        {
            return countryService.GetCountries(numCountries, cancellationToken);
        }
    }
}
