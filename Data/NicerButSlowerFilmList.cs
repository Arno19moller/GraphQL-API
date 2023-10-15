namespace GraphQL_API.Data;

public class NicerButSlowerFilmList
{
    [GraphQLType(typeof(IdType))]
    public ushort Fid { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    [GraphQLType(typeof(FloatType))]
    public decimal Price { get; set; }

    [GraphQLType(typeof(IntType))]
    public ushort? Length { get; set; }

    public string? Rating { get; set; }

    public string? Actors { get; set; }
}
