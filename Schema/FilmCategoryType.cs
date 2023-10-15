using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class FilmCategoryType : ObjectType<FilmCategory>
{
    protected override void Configure(IObjectTypeDescriptor<FilmCategory> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.FilmId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.CategoryId)
           .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.LastUpdate)
           .Type<NonNullType<DateTimeType>>();

        descriptor.Field<FilmCategoryType>(a => a.ResolveCategory(default, default, default))
            .Name("Category")
            .Type<CategoryType>();

        descriptor.Field<FilmCategoryType>(a => a.ResolveFilm(default, default, default))
            .Name("Film")
            .Type<FilmType>();
    }

    public async Task<Category> ResolveCategory(IResolverContext context, [Parent] FilmCategory filmCategory, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<byte, Category>(
            async (ids, ct) =>
            {
                return await dbContext.Categories.Where(x => ids.Contains(x.CategoryId)).ToDictionaryAsync(x => x.CategoryId, x => x, ct);
            })
        .LoadAsync(filmCategory.CategoryId);
    }

    public async Task<Film> ResolveFilm(IResolverContext context, [Parent] FilmCategory filmCategory, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, Film>(
            async (ids, ct) =>
            {
                return await dbContext.Films.Where(x => ids.Contains(x.FilmId)).ToDictionaryAsync(x => x.FilmId, x => x, ct);
            })
        .LoadAsync(filmCategory.FilmId);
    }
}
