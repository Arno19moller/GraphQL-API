using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class FilmDataService : IFilmDataService
    {
        private readonly SakilaContext _dbContext;

        public FilmDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
