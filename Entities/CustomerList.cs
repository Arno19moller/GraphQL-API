using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class CustomerList
{
    [GraphQLType(typeof(IdType))]
    public ushort Id { get; set; }

    public string? Name { get; set; }

    public string Address { get; set; } = null!;

    public string? ZipCode { get; set; }

    public string Phone { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Notes { get; set; } = null!;

    [GraphQLType(typeof(IdType))]
    public byte Sid { get; set; }
}
