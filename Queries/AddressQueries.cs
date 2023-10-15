using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class AddressQueries
	{
        public async Task<List<AddressEntity>> GetAddressData(int numAdresses, [Service] IAddressDataService addressService, CancellationToken cancellationToken)
        {
            //return addressService.GetAddresses(numAdresses, cancellationToken);
            return await addressService.GetAddressesAsync(numAdresses, cancellationToken);
		}
    }
}
