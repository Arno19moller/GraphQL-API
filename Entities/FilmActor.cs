using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class FilmActor
{
	[GraphQLType(typeof(IntType))]
	public ushort ActorId { get; set; }

	[GraphQLType(typeof(IntType))]
	public ushort FilmId { get; set; }

    public DateTime LastUpdate { get; set; }

    public virtual Actor Actor { get; set; } = null!;

    public virtual Film Film { get; set; } = null!;
}
