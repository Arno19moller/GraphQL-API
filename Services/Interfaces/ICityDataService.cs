using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface ICityDataService
    {
        List<CityType> GetCities(int numCities, CancellationToken cancellationToken = default);
    }
}
