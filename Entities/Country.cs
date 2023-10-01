using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class Country
{
    [GraphQLType(typeof(IdType))]
    public ushort CountryId { get; set; }

    public string Country1 { get; set; } = null!;

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
