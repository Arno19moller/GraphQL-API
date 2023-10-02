using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface ICustomerDataService
    {
        List<CustomerType> GetCustomers(int numCustomers, CancellationToken cancellationToken = default);
    }
}
