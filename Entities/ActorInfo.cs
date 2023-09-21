using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class ActorInfo
{
    [GraphQLType(typeof(IntType))]
    public ushort ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? FilmInfo { get; set; }
}
