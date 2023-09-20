using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class StaffDataService: IStaffDataService
    {
        private readonly SakilaContext _dbContext;

        public StaffDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
