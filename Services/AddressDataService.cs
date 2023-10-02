using GraphQL_API.Context;
using GraphQL_API.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class AddressDataService : IAddressDataService
    {
        private readonly SakilaContext _dbContext;

        public AddressDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Address> GetAddresses(int numAddresses, CancellationToken cancellationToken = default)
        {
            return _dbContext.Addresses
                             .Include(x => x.City)
                             .Include(x => x.Customers)
                             .Include(x => x.Staff)
                             .Include(x => x.Stores)
                             .AsNoTracking()
                             .Take(numAddresses)
                             .ToList();
        }
    }
}
