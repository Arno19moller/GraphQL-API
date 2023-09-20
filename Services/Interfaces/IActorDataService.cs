using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface IActorDataService
    {
        List<Actor> GetActorsAsync(int numActors, CancellationToken cancellationToken = default);
    }
}
