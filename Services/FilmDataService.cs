using GraphQL.Data;
using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public class FilmDataService : IFilmDataService
    {
        private readonly SakilaContext _dbContext;

        public FilmDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Film> GetFilms(int numFilms, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
