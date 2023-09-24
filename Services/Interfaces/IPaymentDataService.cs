﻿using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface IPaymentDataService
    {
        List<Payment> GetPayments(int numPayments, CancellationToken cancellationToken = default);
    }
}
