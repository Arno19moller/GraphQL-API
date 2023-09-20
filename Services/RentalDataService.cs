using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class RentalDataService: IRentalDataService
    {
        private readonly SakilaContext _dbContext;

        public RentalDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
