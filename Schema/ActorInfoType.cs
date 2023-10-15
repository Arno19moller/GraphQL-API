namespace GraphQL_API.Data;

public class ActorInfoType : ObjectType<ActorInfo>
{
    protected override void Configure(IObjectTypeDescriptor<ActorInfo> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.ActorId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.FirstName)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastName)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.FilmInfo)
            .Type<StringType>();
    }
}
