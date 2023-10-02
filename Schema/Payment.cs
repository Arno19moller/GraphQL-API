namespace GraphQL_API.Data;

public class PaymentType : ObjectType<Payment>
{
    protected override void Configure(IObjectTypeDescriptor<Payment> descriptor)
    {
        base.Configure(descriptor);
    }
    [GraphQLType(typeof(IdType))]
    public ushort PaymentId { get; set; }

    [GraphQLType(typeof(IdType))]
    public ushort CustomerId { get; set; }

    [GraphQLType(typeof(IdType))]
    public byte StaffId { get; set; }

    [GraphQLType(typeof(IdType))]
    public int? RentalId { get; set; }

    [GraphQLType(typeof(IntType))]
    public decimal Amount { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime PaymentDate { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime? LastUpdate { get; set; }

    public virtual CustomerType Customer { get; set; } = null!;

    public virtual Rental? Rental { get; set; }

    public virtual Staff Staff { get; set; } = null!;
}
