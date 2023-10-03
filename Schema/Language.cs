namespace GraphQL_API.Data;

public class LanguageType : ObjectType<Language>
{
    protected override void Configure(IObjectTypeDescriptor<Language> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.LanguageId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Name)
           .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastUpdate)
           .Type<NonNullType<DateTimeType>>();
    }

    public virtual ICollection<Film> FilmLanguages { get; set; } = new List<Film>();

    public virtual ICollection<Film> FilmOriginalLanguages { get; set; } = new List<Film>();
}
