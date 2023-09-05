using GraphQL.Data;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services
{
	public class ActorDataService: IActorDataService
	{
		private readonly SakilaContext _dbContext;

		public ActorDataService(SakilaContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Actor>> GetActorsAsync(int numActors, CancellationToken cancellationToken = default)
		{
			return await _dbContext.Actors.Include(x => x.FilmActors)
								 .Take(numActors)
								 .ToListAsync(cancellationToken);
		}

		public Task<List<FilmActor>> GetFilmActors(int numFilmActors, CancellationToken cancellationToken = default)
		{
			return _dbContext.FilmActors.Include(x => x.Actor)
							   .Include(x => x.Film)
							   .Take(numFilmActors)
							   .ToListAsync(cancellationToken);
		}
	}
}
