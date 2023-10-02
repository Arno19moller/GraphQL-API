using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class StoreQueries
	{
        public async Task<List<Store>> GetStoreData(int numStores, [Service] IStoreDataService storeService, CancellationToken cancellationToken)
        {
            return storeService.GetStores(numStores, cancellationToken);
        }
    }
}
