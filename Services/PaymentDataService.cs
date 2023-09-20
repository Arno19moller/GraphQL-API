using GraphQL.Data;
using GraphQL.Entities;

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
            throw new NotImplementedException();
        }
    }
}
