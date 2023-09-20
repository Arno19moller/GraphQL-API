using GraphQL.Data;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class FilmActorDataService: IFilmActorDataService
    {
        private readonly SakilaContext _dbContext;

        public FilmActorDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FilmActor> GetFilmActors(int numFilmActors, CancellationToken cancellationToken = default)
        {
            return _dbContext.FilmActors.Include(x => x.Actor)
                               .AsNoTracking()
                               .Include(x => x.Film)
                               .Take(numFilmActors)
                               .ToList();
        }
    }
}
