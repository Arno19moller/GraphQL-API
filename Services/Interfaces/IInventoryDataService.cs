using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface IInventoryDataService
    {
        List<Inventory> GetInventories(int numInventories, CancellationToken cancellationToken = default);
    }
}
