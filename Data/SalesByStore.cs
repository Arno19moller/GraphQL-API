namespace GraphQL_API.Data;

public class SalesByStore
{
    public string? Store { get; set; }

    public string? Manager { get; set; }

    [GraphQLType(typeof(FloatType))]
    public decimal? TotalSales { get; set; }
}
