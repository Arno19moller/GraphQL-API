using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class FilmCategory
{
    [GraphQLType(typeof(IntType))]
    public ushort FilmId { get; set; }

    [GraphQLType(typeof(IntType))]
    public byte CategoryId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Film Film { get; set; } = null!;
}
