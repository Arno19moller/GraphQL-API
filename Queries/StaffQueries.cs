using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class StaffQueries
	{
        public async Task<List<Staff>> GetStaffData(int numStaff, [Service] IStaffDataService staffService, CancellationToken cancellationToken)
        {
            return staffService.GetStaff(numStaff, cancellationToken);
        }
    }
}
