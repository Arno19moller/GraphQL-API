using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class Payment
{
    [GraphQLType(typeof(IntType))]
    public ushort PaymentId { get; set; }

    [GraphQLType(typeof(IntType))]
    public ushort CustomerId { get; set; }

    [GraphQLType(typeof(IntType))]
    public byte StaffId { get; set; }

    [GraphQLType(typeof(IntType))]
    public int? RentalId { get; set; }

    [GraphQLType(typeof(IntType))]
    public decimal Amount { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime PaymentDate { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime? LastUpdate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Rental? Rental { get; set; }

    public virtual Staff Staff { get; set; } = null!;
}
