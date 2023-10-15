using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class ActorQueries
	{
		public async Task<List<Actor>> GetActorData(int numActors, [Service] IActorDataService actorService, CancellationToken cancellationToken)
		{
			try
			{
				//return actorService.GetActors(numActors, cancellationToken);
				return await actorService.GetActorsAsync(numActors, cancellationToken);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			// return actorService.GetActors(numActors, cancellationToken);
		}
    }
}
