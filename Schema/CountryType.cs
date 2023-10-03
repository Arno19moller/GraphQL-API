namespace GraphQL_API.Data;

public class CountryType : ObjectType<Country>
{
    protected override void Configure(IObjectTypeDescriptor<Country> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.CountryId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Country1)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();
    }
}
