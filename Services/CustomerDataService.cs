using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly SakilaContext _dbContext;

        public CustomerDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
