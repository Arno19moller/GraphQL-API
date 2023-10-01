using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class Store
{
    [GraphQLType(typeof(IdType))]
    public byte StoreId { get; set; }

    [GraphQLType(typeof(IdType))]
    public byte ManagerStaffId { get; set; }

    [GraphQLType(typeof(IdType))]
    public ushort AddressId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual Staff ManagerStaff { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
