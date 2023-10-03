﻿namespace GraphQL_API.Data;

public class CountryType : ObjectType<Country>
{
    protected override void Configure(IObjectTypeDescriptor<Country> descriptor)
    {
        base.Configure(descriptor);
    }
    [GraphQLType(typeof(IdType))]
    public ushort CountryId { get; set; }

    public string Country1 { get; set; } = null!;

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual ICollection<CityType> Cities { get; set; } = new List<CityType>();
}