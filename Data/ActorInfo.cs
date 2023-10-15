namespace GraphQL_API.Data;

public class ActorInfo
{
    [GraphQLType(typeof(IdType))]
    public ushort ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? FilmInfo { get; set; }
}
