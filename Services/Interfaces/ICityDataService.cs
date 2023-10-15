using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface ICityDataService
    {
        List<CityEntity> GetCities(int numCities, CancellationToken cancellationToken = default);
    }
}
