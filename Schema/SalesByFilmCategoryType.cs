namespace GraphQL_API.Data;

public class SalesByFilmCategoryType : ObjectType<SalesByFilmCategory>
{
    protected override void Configure(IObjectTypeDescriptor<SalesByFilmCategory> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.Category)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.TotalSales)
            .Type<NonNullType<FloatType>>();
    }
}
