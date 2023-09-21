using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class PaymentQueries
	{
        public async Task<List<Payment>> GetPaymentData(int numPayment, [Service] IPaymentDataService paymentService, CancellationToken cancellationToken)
        {
            return paymentService.GetPayments(numPayment, cancellationToken);
        }
    }
}
