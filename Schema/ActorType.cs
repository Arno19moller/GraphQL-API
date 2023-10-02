namespace GraphQL_API.Data;

public class ActorType : ObjectType<Actor>
{
    protected override void Configure(IObjectTypeDescriptor<Actor> descriptor)
    {
        base.Configure(descriptor);
    }
    [GraphQLType(typeof(IdType))]
    public ushort ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    //[GraphQLIgnore]
    public virtual ICollection<FilmActor>? FilmActors { get; set; } = new List<FilmActor>();
}