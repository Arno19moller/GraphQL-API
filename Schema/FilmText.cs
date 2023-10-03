namespace GraphQL_API.Data;

public class FilmTextType : ObjectType<FilmText>
{
    protected override void Configure(IObjectTypeDescriptor<FilmText> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.FilmId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Title)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Description)
            .Type<NonNullType<StringType>>();
    }
}
