using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class FilmActor
{
	[GraphQLType(typeof(IdType))]
	public ushort ActorId { get; set; }

	[GraphQLType(typeof(IdType))]
	public ushort FilmId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual Actor Actor { get; set; } = null!;

    public virtual Film Film { get; set; } = null!;
}
