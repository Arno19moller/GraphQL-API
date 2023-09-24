using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class ActorQueries
	{
		public async Task<List<Actor>> GetActorData(int numActors, [Service] IActorDataService actorService, CancellationToken cancellationToken)
		{
			return actorService.GetActors(numActors, cancellationToken);
		}
    }
}
