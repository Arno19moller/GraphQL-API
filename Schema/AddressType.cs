using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using MySql.Data.Types;

namespace GraphQL_API.Data;

public class AddressType : ObjectType<AddressEntity>
{
    protected override void Configure(IObjectTypeDescriptor<AddressEntity> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.AddressId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Address)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Address2)
            .Type<StringType>();

        descriptor.Field(a => a.District)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.CityId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.PostalCode)
            .Type<StringType>();

        descriptor.Field(a => a.Phone)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field<AddressType>(a => a.ResolveCity(default, default, default))
            .Name("City")
            .Type<CityType>();

        descriptor.Field<AddressType>(a => a.ResolveStores(default, default, default))
            .Name("Stores")
            .Type<ListType<StoreType>>();

        descriptor.Field<AddressType>(a => a.ResolveStaff(default, default, default))
            .Name("Staff")
            .Type<ListType<StaffType>>();
    }

    public async Task<CityEntity> ResolveCity(IResolverContext context, [Parent] AddressEntity adrress, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, CityEntity>(
            async (ids, ct) =>
            {
                return await dbContext.Cities.Where(x => ids.Contains(x.CityId)).ToDictionaryAsync(x => x.CityId, x => x, ct);
            })
        .LoadAsync(adrress.CityId);
    }

    public async Task<IEnumerable<Store>> ResolveStores(IResolverContext context, [Parent] AddressEntity address, [Service] SakilaContext dbContext)
    {
        var stores = await context.BatchDataLoader<ushort, IEnumerable<Store>>(
            async (ids, ct) =>
            {
                var storesByAddressId = await dbContext.Stores.Where(x => ids.Contains(x.AddressId)).ToListAsync(ct);
                return ids.ToDictionary(id => id, id => storesByAddressId.Where(store => store.AddressId == id).AsEnumerable());
            })
        .LoadAsync(address.AddressId);

        return stores;
    }

   public async Task<IEnumerable<Staff>> ResolveStaff(IResolverContext context, [Parent] AddressEntity address, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, IEnumerable<Staff>>(
            async (ids, ct) =>
            {
                var staffByAddressId = await dbContext.Staff.Where(x => ids.Contains(x.AddressId)).ToListAsync(ct);
                return ids.ToDictionary(id => id, id => staffByAddressId.Where(staff => staff.AddressId == id).AsEnumerable());
            })
        .LoadAsync(address.AddressId);
    }
}
