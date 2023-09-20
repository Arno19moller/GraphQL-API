using GraphQL.Data;
using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public class RentalDataService: IRentalDataService
    {
        private readonly SakilaContext _dbContext;

        public RentalDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Rental> GetRentals(int numRentals, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
