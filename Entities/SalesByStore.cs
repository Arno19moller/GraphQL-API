using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class SalesByStore
{
    public string? Store { get; set; }

    public string? Manager { get; set; }

    [GraphQLType(typeof(FloatType))]
    public decimal? TotalSales { get; set; }
}
