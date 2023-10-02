using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface ICountryDataService
    {
        List<CountryType> GetCountries(int numCountries, CancellationToken cancellationToken = default);
    }
}
