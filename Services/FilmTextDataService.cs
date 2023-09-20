using GraphQL.Data;
using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public class FilmTextDataService : IFilmTextDataService
    {
        private readonly SakilaContext _dbContext;

        public FilmTextDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Film> GetFilmTexts(int numFilmTexts, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
