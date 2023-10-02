using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class CityQueries
	{
        public async Task<List<City>> GetCityData(int numCities, [Service] ICityDataService cityService, CancellationToken cancellationToken)
        {
            return cityService.GetCities(numCities, cancellationToken);
        }
    }
}
