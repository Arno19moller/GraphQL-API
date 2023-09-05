using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class Film
{
	[GraphQLType(typeof(IntType))]
	public ushort FilmId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

	[GraphQLType(typeof(IntType))]
	public int? ReleaseYear { get; set; }

    [GraphQLType(typeof(IntType))]
    public byte LanguageId { get; set; }

	[GraphQLType(typeof(IntType))]
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

    public DateTime LastUpdate { get; set; }
	[GraphQLIgnore]
	public virtual ICollection<FilmActor> FilmActors { get; set; } = new List<FilmActor>();
	[GraphQLIgnore]
	public virtual ICollection<FilmCategory> FilmCategories { get; set; } = new List<FilmCategory>();
	[GraphQLIgnore]
	public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
	[GraphQLIgnore]
	public virtual Language Language { get; set; } = null!;
	[GraphQLIgnore]
	public virtual Language? OriginalLanguage { get; set; }
}
