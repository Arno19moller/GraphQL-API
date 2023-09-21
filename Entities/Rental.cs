using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class Rental
{
    [GraphQLType(typeof(IntType))]
    public int RentalId { get; set; }

    public DateTime RentalDate { get; set; }

    [GraphQLType(typeof(IntType))]
    public uint InventoryId { get; set; }

    [GraphQLType(typeof(IntType))]
    public ushort CustomerId { get; set; }

    public DateTime? ReturnDate { get; set; }

    [GraphQLType(typeof(IntType))]
    public byte StaffId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Inventory Inventory { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Staff Staff { get; set; } = null!;
}
