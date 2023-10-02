namespace GraphQL_API.Data;

public class FilmType : ObjectType<Film>
{
    protected override void Configure(IObjectTypeDescriptor<Film> descriptor)
    {
        base.Configure(descriptor);
    }
    [GraphQLType(typeof(IdType))]
    public ushort FilmId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [GraphQLType(typeof(IntType))]
    public int? ReleaseYear { get; set; }

    [GraphQLType(typeof(IdType))]
    public byte LanguageId { get; set; }

    [GraphQLType(typeof(IdType))]
    public byte? OriginalLanguageId { get; set; }

    [GraphQLType(typeof(IntType))]
    public byte RentalDuration { get; set; }

    [GraphQLType(typeof(FloatType))]
    public decimal RentalRate { get; set; }

    [GraphQLType(typeof(IntType))]
    public ushort? Length { get; set; }

    [GraphQLType(typeof(FloatType))]
    public decimal ReplacementCost { get; set; }

    public string? Rating { get; set; }

    public string? SpecialFeatures { get; set; }

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }


    public virtual ICollection<FilmActor> FilmActors { get; set; } = new List<FilmActor>();


    public virtual ICollection<FilmCategory> FilmCategories { get; set; } = new List<FilmCategory>();


    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();


    public virtual Language Language { get; set; } = null!;


    public virtual Language? OriginalLanguage { get; set; }
}
