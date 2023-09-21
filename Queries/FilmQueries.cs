using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class FilmQueries
    {
        public async Task<List<Film>> GetFilmData(int numFilm, [Service] IFilmDataService filmService, CancellationToken cancellationToken)
        {
            return filmService.GetFilms(numFilm, cancellationToken);
        }
    }
}
