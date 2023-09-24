using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class CountryQueries
	{
        public async Task<List<Country>> GetCountryData(int numCountries, [Service] ICountryDataService countryService, CancellationToken cancellationToken)
        {
            return countryService.GetCountries(numCountries, cancellationToken);
        }
    }
}
