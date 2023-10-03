using MySql.Data.Types;

namespace GraphQL_API.Data;

public class AddressEntity
{
    [GraphQLType(typeof(IdType))]
    public ushort AddressId { get; set; }

    public string Address { get; set; } = null!;

    public string? Address2 { get; set; }

    public string District { get; set; } = null!;

    [GraphQLType(typeof(IdType))]
    public ushort CityId { get; set; }

    public string? PostalCode { get; set; }

    public string Phone { get; set; } = null!;

    [GraphQLIgnore]
    public MySqlGeometry Location { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual CityType City { get; set; } = null!;

    public virtual ICollection<CustomerType> Customers { get; set; } = new List<CustomerType>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
