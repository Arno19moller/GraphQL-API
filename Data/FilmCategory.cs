namespace GraphQL_API.Data;

public class FilmCategory
{
    [GraphQLType(typeof(IdType))]
    public ushort FilmId { get; set; }

    [GraphQLType(typeof(IdType))]
    public byte CategoryId { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual CategoryType Category { get; set; } = null!;

    public virtual Film Film { get; set; } = null!;
}
