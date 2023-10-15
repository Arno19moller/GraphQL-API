namespace GraphQL_API.Data;

public class FilmText
{
    [GraphQLType(typeof(IdType))]
    public short FilmId { get; set; }

    [GraphQLType(typeof(StringType))]
    public string Title { get; set; } = null!;

    [GraphQLType(typeof(StringType))]
    public string? Description { get; set; }
}
