using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class StaffList
{
    [GraphQLType(typeof(IntType))]
    public byte Id { get; set; }

    public string? Name { get; set; }

    public string Address { get; set; } = null!;

    public string? ZipCode { get; set; }

    public string Phone { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    [GraphQLType(typeof(IntType))]
    public byte Sid { get; set; }
}
