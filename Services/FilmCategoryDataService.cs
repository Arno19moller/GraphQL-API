using GraphQL.Data;
using GraphQL.Entities;

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
            throw new NotImplementedException();
        }
    }
}
