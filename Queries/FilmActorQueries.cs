using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class FilmActorQueries
	{
        public async Task<List<FilmActor>> GetFilmActors(int numFilmActors, [Service] IFilmActorDataService filmActorService, CancellationToken cancellationToken)
		{
			return filmActorService.GetFilmActors(numFilmActors, cancellationToken);
		}
    }
}
