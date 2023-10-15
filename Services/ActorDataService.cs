using GraphQL_API.Context;
using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
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

		public List<Actor> GetActors(int numActors, CancellationToken cancellationToken = default)
		{
			try
			{
                return _dbContext.Actors
                             //.Include(x => x.FilmActors)
                             .AsNoTracking()
                             .Take(numActors)
                             .ToList();
            }
			catch (Exception e)
			{
				throw;
			}
			
		}
	}
}
