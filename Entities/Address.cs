using System;
using System.Collections.Generic;
using MySql.Data.Types;

namespace GraphQL.Entities;

public partial class Address
{
    [GraphQLType(typeof(IdType))]
    public ushort AddressId { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string District { get; set; } = null!;

    [GraphQLType(typeof(IdType))]
    public ushort CityId { get; set; }

    public string? PostalCode { get; set; }

    public string Phone { get; set; } = null!;

    [GraphQLIgnore]
    public MySqlGeometry Location { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
