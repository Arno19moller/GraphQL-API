using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class PaymentDataService: IPaymentDataService
    {
        private readonly SakilaContext _dbContext;

        public PaymentDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
