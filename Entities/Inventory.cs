using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class Inventory
{
    [GraphQLType(typeof(IntType))]
    public uint InventoryId { get; set; }

    [GraphQLType(typeof(IntType))]
    public ushort FilmId { get; set; }

    [GraphQLType(typeof(IntType))]
    public byte StoreId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual Film Film { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual Store Store { get; set; } = null!;
}
