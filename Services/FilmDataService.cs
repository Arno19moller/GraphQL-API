using GraphQL.Data;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

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
            return _dbContext.Films
                .Include(x => x.Inventories)
                .Include(x => x.FilmActors)
                .Include(x => x.FilmCategories)
                .Include(x => x.Language)
                .Include(x => x.OriginalLanguage)
                .AsNoTracking()
                .Take(numFilms)
                .ToList();
        }
    }
}
