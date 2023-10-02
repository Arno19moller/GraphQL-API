namespace GraphQL_API.Data;

public class SalesByFilmCategoryType : ObjectType<SalesByFilmCategory>
{
    protected override void Configure(IObjectTypeDescriptor<SalesByFilmCategory> descriptor)
    {
        base.Configure(descriptor);
    }
    public string Category { get; set; } = null!;

    [GraphQLType(typeof(FloatType))]
    public decimal? TotalSales { get; set; }
}
