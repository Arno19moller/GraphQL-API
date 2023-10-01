using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class FilmText
{
    [GraphQLType(typeof(IdType))]
    public short FilmId { get; set; }

    [GraphQLType(typeof(StringType))]
    public string Title { get; set; } = null!;

    [GraphQLType(typeof(StringType))]
    public string? Description { get; set; }
}
