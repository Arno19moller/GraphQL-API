using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class FilmCategoryDataService : IFilmCategoryDataService
    {
        private readonly SakilaContext _dbContext;

        public FilmCategoryDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
