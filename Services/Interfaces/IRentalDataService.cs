using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface IRentalDataService
    {
        List<Rental> GetRentals(int numRentals, CancellationToken cancellationToken = default);
    }
}
