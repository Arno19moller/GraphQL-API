using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface IStaffDataService
    {
        List<Staff> GetStaff(int numStaff, CancellationToken cancellationToken = default);
    }
}
