using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class City
{
    [GraphQLType(typeof(IdType))]
    public ushort CityId { get; set; }

    public string City1 { get; set; } = null!;

    [GraphQLType(typeof(IdType))]
    public ushort CountryId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;
}
