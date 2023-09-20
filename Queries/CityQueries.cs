using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class CityQueries
	{
        public async Task<List<Actor>> GetCityData(int numActors, [Service] IActorDataService actorService, CancellationToken cancellationToken)
        {
            return actorService.GetActorsAsync(numActors, cancellationToken);
        }
    }
}
