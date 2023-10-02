using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface IFilmActorDataService
    {
        List<FilmActor> GetFilmActors(int numFilmActors, CancellationToken cancellationToken = default);
    }
}
