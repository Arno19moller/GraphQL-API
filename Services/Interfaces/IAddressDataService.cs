using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface IAddressDataService
    {
        List<AddressEntity> GetAddresses(int numAddresses, CancellationToken cancellationToken = default);
    }
}
