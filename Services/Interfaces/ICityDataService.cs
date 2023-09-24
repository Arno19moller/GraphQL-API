using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface ICityDataService
    {
        List<City> GetCities(int numCities, CancellationToken cancellationToken = default);
    }
}
