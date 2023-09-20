using GraphQL.Data;
using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly SakilaContext _dbContext;

        public CustomerDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Customer> GetCustomers(int numCustomers, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
