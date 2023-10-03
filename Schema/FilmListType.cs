namespace GraphQL_API.Data;

public class FilmListType : ObjectType<FilmList>
{
    protected override void Configure(IObjectTypeDescriptor<FilmList> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.Fid)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Title)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Description)
            .Type<StringType>();

        descriptor.Field(a => a.Category)
            .Type<StringType>();

        descriptor.Field(a => a.Price)
            .Type<NonNullType<FloatType>>();

        descriptor.Field(a => a.Length)
            .Type<IntType>();

        descriptor.Field(a => a.Rating)
            .Type<StringType>();

        descriptor.Field(a => a.Actors)
            .Type<StringType>();
    }
}
