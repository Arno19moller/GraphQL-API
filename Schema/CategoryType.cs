namespace GraphQL_API.Data;

public class CategoryType : ObjectType<Category>
{
    protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
    {
        base.Configure(descriptor);
    }
    [GraphQLType(typeof(IdType))]
    public byte CategoryId { get; set; }

    public string Name { get; set; } = null!;

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual ICollection<FilmCategory> FilmCategories { get; set; } = new List<FilmCategory>();
}
