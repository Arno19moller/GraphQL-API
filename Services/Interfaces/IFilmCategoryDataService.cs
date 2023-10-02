using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface IFilmCategoryDataService
    {
        List<FilmCategory> GetFilmCategories(int numFilmCategories, CancellationToken cancellationToken = default);
    }
}
