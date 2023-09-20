using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class AddressDataService : IAddressDataService
    {
        private readonly SakilaContext _dbContext;

        public AddressDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
