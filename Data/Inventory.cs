namespace GraphQL_API.Data;

public class Inventory
{
    [GraphQLType(typeof(IdType))]
    public uint InventoryId { get; set; }

    [GraphQLType(typeof(IdType))]
    public ushort FilmId { get; set; }

    [GraphQLType(typeof(IdType))]
    public byte StoreId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual Film Film { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual Store Store { get; set; } = null!;
}
