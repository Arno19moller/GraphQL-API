using GraphQL.Data;
using GraphQL.Entities;

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
            throw new NotImplementedException();
        }
    }
}
