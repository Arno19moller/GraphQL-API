using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface IFilmTextDataService
    {
        List<Film> GetFilmTexts(int numFilmTexts, CancellationToken cancellationToken = default);
    }
}
