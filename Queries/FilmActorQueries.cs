using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class FilmActorQueries
	{
        public async Task<List<FilmActor>> GetFilmActorsAsync(int numFilmActors, [Service] IActorDataService actorService, CancellationToken cancellationToken)
		{
			return actorService.GetFilmActors(numFilmActors, cancellationToken);
		}
    }
}
