using GraphQL_API.Context;
using GraphQL_API.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly SakilaContext _dbContext;

        public CustomerDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CustomerType> GetCustomers(int numCustomers, CancellationToken cancellationToken = default)
        {
            return _dbContext.Customers
                .Include(x => x.Address)
                .Include(x => x.Store)
                .Include(x => x.Payments)
                .Include(x => x.Rentals)
                .AsNoTracking()
                .Take(numCustomers)
                .ToList();
        }
    }
}
