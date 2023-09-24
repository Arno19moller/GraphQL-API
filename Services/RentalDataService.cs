using GraphQL.Data;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

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
            return _dbContext.Rentals
                .Include(x => x.Customer)
                .Include(x => x.Inventory)
                .Include(x => x.Payments)
                .Include(x => x.Staff)
                .AsNoTracking()
                .Take(numRentals)
                .ToList();
        }
    }
}
