namespace GraphQL_API.Data;

public class ActorInfoType : ObjectType<Actor>
{
    protected override void Configure(IObjectTypeDescriptor<Actor> descriptor)
    {
        base.Configure(descriptor);
    }
    [GraphQLType(typeof(IdType))]
    public ushort ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? FilmInfo { get; set; }
}
