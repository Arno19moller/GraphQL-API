namespace GraphQL_API.Data;

public class SalesByStoreType : ObjectType<SalesByStore>
{
    protected override void Configure(IObjectTypeDescriptor<SalesByStore> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.Store)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Manager)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.TotalSales)
            .Type<NonNullType<FloatType>>();
    }
}
