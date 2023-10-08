namespace GraphQL_API.Data;

public class CityEntity
{
    [GraphQLType(typeof(IdType))]
    public ushort CityId { get; set; }

    public string City { get; set; } = null!;

    [GraphQLType(typeof(IdType))]
    public ushort CountryId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual ICollection<AddressEntity> Addresses { get; set; } = new List<AddressEntity>();

    public virtual Country Country { get; set; } = null!;
}
