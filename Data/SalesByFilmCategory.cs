namespace GraphQL_API.Data;

public class SalesByFilmCategory
{
    public string Category { get; set; } = null!;

    [GraphQLType(typeof(FloatType))]
    public decimal? TotalSales { get; set; }
}
