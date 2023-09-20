using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface IAddressDataService
    {
        List<Address> GetAddresses(int numAddresses, CancellationToken cancellationToken = default);
    }
}
