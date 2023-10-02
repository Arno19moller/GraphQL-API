namespace GraphQL_API.Data;

public class Category
{
    [GraphQLType(typeof(IdType))]
    public byte CategoryId { get; set; }

    public string Name { get; set; } = null!;

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual ICollection<FilmCategory> FilmCategories { get; set; } = new List<FilmCategory>();
}
