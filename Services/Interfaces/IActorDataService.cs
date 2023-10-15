using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface IActorDataService
    {
        List<Actor> GetActors(int numActors, CancellationToken cancellationToken = default);
        Task<List<Actor>> GetActorsAsync(int numActors, CancellationToken cancellationToken = default);
	}
}
