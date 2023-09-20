using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface IActorDataService
    {
        List<Actor> GetActors(int numActors, CancellationToken cancellationToken = default);
    }
}
