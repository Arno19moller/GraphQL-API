using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class FilmType : ObjectType<Film>
{
    protected override void Configure(IObjectTypeDescriptor<Film> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.FilmId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Title)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Description)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.ReleaseYear)
            .Type<NonNullType<IntType>>();

        descriptor.Field(a => a.LanguageId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.OriginalLanguageId)
            .Type<IdType>();

        descriptor.Field(a => a.RentalDuration)
            .Type<NonNullType<IntType>>();

        descriptor.Field(a => a.RentalRate)
            .Type<NonNullType<FloatType>>();

        descriptor.Field(a => a.Length)
            .Type<NonNullType<IntType>>();

        descriptor.Field(a => a.ReplacementCost)
            .Type<NonNullType<FloatType>>();

        descriptor.Field(a => a.Rating)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.SpecialFeatures)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field<FilmType>(a => a.ResolveLanguage(default, default, default))
            .Name("language")
            .Type<LanguageType>();

        descriptor.Field<FilmType>(a => a.ResolveOriginalLanguage(default, default, default))
            .Name("originalLanguage")
            .Type<LanguageType>();

		descriptor.Field<FilmType>(a => a.ResolveInventories(default, default, default))
			.Name("inventories")
			.Type<ListType<InventoryType>>();
	}

    public async Task<Language> ResolveLanguage(IResolverContext context, [Parent] Film film, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<byte, Language>(
            async (ids, ct) =>
            {
                return await dbContext.Languages.Where(x => ids.Contains(x.LanguageId)).ToDictionaryAsync(x => x.LanguageId, x => x, ct);
            })
        .LoadAsync(film.LanguageId);
    }

    public async Task<Language?> ResolveOriginalLanguage(IResolverContext context, [Parent] Film film, [Service] SakilaContext dbContext)
    {
        return (Language?)await context.BatchDataLoader<byte, Language>(
            async (ids, ct) =>
            {
                return await dbContext.Languages.Where(x => ids.Contains(x.LanguageId)).ToDictionaryAsync(x => x.LanguageId, x => x, ct);
            })
        .LoadAsync(film.OriginalLanguageId);
    }

	public async Task<IEnumerable<Inventory>> ResolveInventories(IResolverContext context, [Parent] Film film, [Service] SakilaContext dbContext)
	{
		return await context.BatchDataLoader<ushort, IEnumerable<Inventory>>(
			async (ids, ct) =>
			{
				var inventoriesByFilmId = await dbContext.Inventories.Where(x => ids.Contains(x.FilmId)).ToListAsync(ct);
				return ids.ToDictionary(id => id, id => inventoriesByFilmId.Where(inventory => inventory.FilmId == id).AsEnumerable());
			})
		.LoadAsync(film.FilmId);
	}
}
