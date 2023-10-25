using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
             .Name("film")
             .Type<FilmType>();

        descriptor.Field<InventoryType>(a => a.ResolveStore(default, default, default))
             .Name("store")
             .Type<StoreType>();

		descriptor.Field<InventoryType>(a => a.ResolveRentals(default, default, default))
			 .Name("rentals")
			 .Type<ListType<RentalType>>();
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

	public async Task<IEnumerable<Rental>> ResolveRentals(IResolverContext context, [Parent] Inventory inventory, [Service] SakilaContext dbContext)
	{
		return await context.BatchDataLoader<uint, IEnumerable<Rental>>(
			async (ids, ct) =>
			{
				var rentalsByInventoryId = await dbContext.Rentals.Where(x => ids.Contains(x.InventoryId)).ToListAsync(ct);
				return ids.ToDictionary(id => id, id => rentalsByInventoryId.Where(rental => rental.InventoryId == id).AsEnumerable());
			})
		.LoadAsync(inventory.InventoryId);
	}
}
