using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface IStoreDataService
    {
        List<Store> GetStores(int numStores, CancellationToken cancellationToken = default);
    }
}
