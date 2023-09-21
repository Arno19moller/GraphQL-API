using GraphQL.Data;
using GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

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
            return _dbContext.Staff
                .Include(x => x.Address)
                .Include(x => x.Payments)
                .Include(x => x.Rentals)
                .Include(x => x.StoreNavigation)
                .Include(x => x.Store)
                .AsNoTracking()
                .Take(numStaff)
                .ToList();
        }
    }
}
