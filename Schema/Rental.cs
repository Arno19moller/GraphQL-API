namespace GraphQL_API.Data;

public class RentalType : ObjectType<Rental>
{
    protected override void Configure(IObjectTypeDescriptor<Rental> descriptor)
    {
        base.Configure(descriptor);
    }
    [GraphQLType(typeof(IdType))]
    public int RentalId { get; set; }

    public DateTime RentalDate { get; set; }

    [GraphQLType(typeof(IdType))]
    public uint InventoryId { get; set; }

    [GraphQLType(typeof(IdType))]
    public ushort CustomerId { get; set; }

    public DateTime? ReturnDate { get; set; }

    [GraphQLType(typeof(IdType))]
    public byte StaffId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual CustomerType Customer { get; set; } = null!;

    public virtual Inventory Inventory { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Staff Staff { get; set; } = null!;
}
