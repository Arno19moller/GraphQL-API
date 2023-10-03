using GraphQL_API.Context;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class CategoryType : ObjectType<Category>
{
    protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.CategoryId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Name)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field<StoreType>(p => ResolveFilmCategory(default, default))
            .Name("FilmCategories")
            .Type<ListType<FilmCategoryType>>();
    }

    public async Task<IReadOnlyList<FilmCategory>> ResolveFilmCategory([Parent] Category category, [Service] SakilaContext sakilaContext)
    {
        return await sakilaContext.FilmCategories
            .Where(x => x.CategoryId == category.CategoryId)
            .ToListAsync();
    }
}
