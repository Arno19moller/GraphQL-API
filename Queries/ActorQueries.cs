using GraphQL.Entities;
using GraphQL_API.Services;
using HotChocolate;

namespace GraphQL_API.Queries
{
	[ExtendObjectType(Name = "Query")]
	public class ActorQueries
	{
		public async Task<List<Actor>> GetActorData(int numActors, [Service] IActorDataService actorService, CancellationToken cancellationToken)
		{
			return await actorService.GetActorsAsync(numActors, cancellationToken);
		}

		public async Task<List<FilmActor>> GetFilmActorsAsync(int numFilmActors, [Service] IActorDataService actorService, CancellationToken cancellationToken)
		{
			return await actorService.GetFilmActors(numFilmActors, cancellationToken);
		}
	}
}
