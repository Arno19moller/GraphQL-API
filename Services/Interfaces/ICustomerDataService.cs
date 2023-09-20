using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface ICustomerDataService
    {
        List<Customer> GetCustomers(int numCustomers, CancellationToken cancellationToken = default);
    }
}
