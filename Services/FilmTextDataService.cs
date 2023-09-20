using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class FilmTextDataService : IFilmTextDataService
    {
        private readonly SakilaContext _dbContext;

        public FilmTextDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
