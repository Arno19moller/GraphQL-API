using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class InventoryType : ObjectType<Inventory>
{
    protected override void Configure(IObjectTypeDescriptor<Inventory> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.InventoryId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.FilmId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.StoreId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field<InventoryType>(a => a.ResolveFilm(default, default, default))
             .Name("Film")
             .Type<FilmType>();

        descriptor.Field<InventoryType>(a => a.ResolveStore(default, default, default))
             .Name("Store")
             .Type<StoreType>();
    }
    public async Task<Film> ResolveFilm(IResolverContext context, [Parent] Inventory inventory, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, Film>(
            async (ids, ct) =>
            {
                return await dbContext.Films.Where(x => ids.Contains(x.FilmId)).ToDictionaryAsync(x => x.FilmId, x => x, ct);
            })
        .LoadAsync(inventory.FilmId);
    }

    public async Task<Store> ResolveStore(IResolverContext context, [Parent] Inventory inventory, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<byte, Store>(
            async (ids, ct) =>
            {
                return await dbContext.Stores.Where(x => ids.Contains(x.StoreId)).ToDictionaryAsync(x => x.StoreId, x => x, ct);
            })
        .LoadAsync(inventory.StoreId);
    }
}
