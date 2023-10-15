namespace GraphQL_API.Data;

public class CustomerListType : ObjectType<CustomerList>
{
    protected override void Configure(IObjectTypeDescriptor<CustomerList> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.Id)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Name)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Address)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.ZipCode)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Phone)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.City)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Country)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Notes)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Sid)
            .Type<NonNullType<IdType>>();
    }
}
