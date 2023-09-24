using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class FilmTextQueries
	{
        public async Task<List<FilmText>> GetFilmTextData(int numFilmTexts, [Service] IFilmTextDataService filmTextService, CancellationToken cancellationToken)
        {
            return filmTextService.GetFilmTexts(numFilmTexts, cancellationToken);
        }
    }
}
