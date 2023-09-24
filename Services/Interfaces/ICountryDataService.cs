using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface ICountryDataService
    {
        List<Country> GetCountries(int numCountries, CancellationToken cancellationToken = default);
    }
}
