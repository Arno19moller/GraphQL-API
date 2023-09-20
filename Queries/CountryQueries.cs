using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class CountryQueries
	{
        public async Task<List<Actor>> GetCountryData(int numActors, [Service] IActorDataService actorService, CancellationToken cancellationToken)
        {
            return actorService.GetActorsAsync(numActors, cancellationToken);
        }
    }
}
