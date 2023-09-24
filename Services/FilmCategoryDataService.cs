using GraphQL.Data;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class FilmCategoryDataService : IFilmCategoryDataService
    {
        private readonly SakilaContext _dbContext;

        public FilmCategoryDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FilmCategory> GetFilmCategories(int numFilmCategories, CancellationToken cancellationToken = default)
        {
            return _dbContext.FilmCategories
                .Include(x => x.Category)
                .Include(x => x.Film)
                .AsNoTracking()
                .Take(numFilmCategories)
                .ToList();
        }
    }
}
