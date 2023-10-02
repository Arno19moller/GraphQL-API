namespace GraphQL_API.Data;

public class CityType : ObjectType<City>
{
    protected override void Configure(IObjectTypeDescriptor<City> descriptor)
    {
        base.Configure(descriptor);
    }
    [GraphQLType(typeof(IdType))]
    public ushort CityId { get; set; }

    public string City1 { get; set; } = null!;

    [GraphQLType(typeof(IdType))]
    public ushort CountryId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual ICollection<AddressType> Addresses { get; set; } = new List<AddressType>();

    public virtual CountryType Country { get; set; } = null!;
}
