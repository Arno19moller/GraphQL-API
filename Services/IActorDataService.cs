using GraphQL.Entities;

namespace GraphQL_API.Services
{
	public interface IActorDataService
	{
		Task<List<Actor>> GetActorsAsync(int numActors, CancellationToken cancellationToken = default); 

		Task<List<FilmActor>> GetFilmActors(int numFilmActors, CancellationToken cancellationToken = default); 
	}
}
