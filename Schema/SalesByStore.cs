namespace GraphQL_API.Data;

public class SalesByStoreType : ObjectType<SalesByStore>
{
    protected override void Configure(IObjectTypeDescriptor<SalesByStore> descriptor)
    {
        base.Configure(descriptor);
    }
    public string? Store { get; set; }

    public string? Manager { get; set; }

    [GraphQLType(typeof(FloatType))]
    public decimal? TotalSales { get; set; }
}
