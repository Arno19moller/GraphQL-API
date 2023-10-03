namespace GraphQL_API.Data;

public class Customer
{
    [GraphQLType(typeof(IdType))]
    public ushort CustomerId { get; set; }

    [GraphQLType(typeof(IdType))]
    public byte StoreId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    [GraphQLType(typeof(IdType))]
    public ushort AddressId { get; set; }

    [GraphQLType(typeof(BooleanType))]
    public bool? Active { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime CreateDate { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime? LastUpdate { get; set; }

    public virtual AddressType Address { get; set; } = null!;

    public virtual ICollection<PaymentType> Payments { get; set; } = new List<PaymentType>();

    public virtual ICollection<RentalType> Rentals { get; set; } = new List<RentalType>();

    public virtual StoreType Store { get; set; } = null!;
}
