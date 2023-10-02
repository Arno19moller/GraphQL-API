using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class FilmCategoryQueries
	{
        public async Task<List<FilmCategory>> GetFilmCategoryData(int numfilmCatefories, [Service] IFilmCategoryDataService filmCategoryService, CancellationToken cancellationToken)
        {
            return filmCategoryService.GetFilmCategories(numfilmCatefories, cancellationToken);
        }
    }
}
