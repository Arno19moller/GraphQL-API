using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class Language
{
    [GraphQLType(typeof(IdType))]
    public byte LanguageId { get; set; }

    public string Name { get; set; } = null!;

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

    public virtual ICollection<Film> FilmLanguages { get; set; } = new List<Film>();

    public virtual ICollection<Film> FilmOriginalLanguages { get; set; } = new List<Film>();
}
