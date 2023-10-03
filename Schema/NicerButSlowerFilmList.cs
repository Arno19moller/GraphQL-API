namespace GraphQL_API.Data;

public class NicerButSlowerFilmListType : ObjectType<NicerButSlowerFilmList>
{
    protected override void Configure(IObjectTypeDescriptor<NicerButSlowerFilmList> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.Fid)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Title)
           .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Description)
           .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Category)
           .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Price)
           .Type<NonNullType<FloatType>>();

        descriptor.Field(a => a.Length)
           .Type<NonNullType<IntType>>();

        descriptor.Field(a => a.Rating)
           .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Actors)
           .Type<NonNullType<StringType>>();
    }
}
