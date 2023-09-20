using GraphQL.Data;
using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public class StaffDataService: IStaffDataService
    {
        private readonly SakilaContext _dbContext;

        public StaffDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Staff> GetStaff(int numStaff, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
