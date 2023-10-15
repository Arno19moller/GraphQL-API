using GraphQL_API.Context;
using GraphQL_API.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class PaymentDataService: IPaymentDataService
    {
        private readonly SakilaContext _dbContext;

        public PaymentDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Payment> GetPayments(int numPayments, CancellationToken cancellationToken = default)
        {
            return _dbContext.Payments
                .Include(x => x.Customer)
                .Include(x => x.Rental)
                .Include(x => x.Staff)
                .AsNoTracking()
                .Take(numPayments)
                .ToList();
        }
    }
}
