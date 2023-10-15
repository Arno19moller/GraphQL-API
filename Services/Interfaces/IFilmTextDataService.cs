using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface IFilmTextDataService
    {
        List<FilmText> GetFilmTexts(int numFilmTexts, CancellationToken cancellationToken = default);
    }
}
