using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class InventoryQueries
	{
        public async Task<List<Inventory>> GetInventoryData(int numInventories, [Service] IInventoryDataService InventoryService, CancellationToken cancellationToken)
        {
            return InventoryService.GetInventories(numInventories, cancellationToken);
        }
    }
}
