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

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual Store Store { get; set; } = null!;
}
