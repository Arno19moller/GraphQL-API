using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class CustomerQueries
	{
        public async Task<List<Customer>> GetCustomerData(int numCustomers, [Service] ICustomerDataService customerService, CancellationToken cancellationToken)
        {
            return customerService.GetCustomers(numCustomers, cancellationToken);
        }
    }
}
