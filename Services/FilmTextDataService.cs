using GraphQL.Data;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class FilmTextDataService : IFilmTextDataService
    {
        private readonly SakilaContext _dbContext;

        public FilmTextDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FilmText> GetFilmTexts(int numFilmTexts, CancellationToken cancellationToken = default)
        {
            return _dbContext.FilmTexts
                .AsNoTracking()
                .Take(numFilmTexts)
                .ToList();
        }
    }
}
