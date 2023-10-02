namespace GraphQL_API.Data;

public class Actor
{
    [GraphQLType(typeof(IdType))]
    public ushort ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    //[GraphQLIgnore]
    public virtual ICollection<FilmActor>? FilmActors { get; set; } = new List<FilmActor>();
}