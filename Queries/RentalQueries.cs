using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class RentalQueries
	{
        public async Task<List<Rental>> GetRentalData(int numRentals, [Service] IRentalDataService actorService, CancellationToken cancellationToken)
        {
            return actorService.GetRentals(numRentals, cancellationToken);
        }
    }
}
