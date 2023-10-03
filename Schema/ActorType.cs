namespace GraphQL_API.Data;

public class ActorType : ObjectType<Actor>
{
    protected override void Configure(IObjectTypeDescriptor<Actor> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.ActorId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.FirstName)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastName)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field(a => a.ActorId)
            .Type<NonNullType<IdType>>();
    }
}