using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class Staff
{
    [GraphQLType(typeof(IdType))]
    public byte StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [GraphQLType(typeof(IdType))]
    public ushort AddressId { get; set; }

    [GraphQLType(typeof(ByteArrayType))]
    public byte[]? Picture { get; set; }

    public string? Email { get; set; }

    [GraphQLType(typeof(IdType))]
    public byte StoreId { get; set; }

    [GraphQLType(typeof(BooleanType))]
    public bool? Active { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual Store Store { get; set; } = null!;

    public virtual Store? StoreNavigation { get; set; }
}
