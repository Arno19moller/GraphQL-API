using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class RentalType : ObjectType<Rental>
{
    protected override void Configure(IObjectTypeDescriptor<Rental> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.RentalId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.RentalDate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field(a => a.InventoryId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.CustomerId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.ReturnDate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field(a => a.StaffId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        ////
        descriptor.Field<RentalType>(a => a.ResolveCustomer(default, default, default))
            .Name("Customer")
            .Type<CustomerType>();

        descriptor.Field<RentalType>(a => a.ResolveInventory(default, default, default))
            .Name("Inventory")
            .Type<InventoryType>();

        descriptor.Field<RentalType>(a => a.ResolveStaff(default, default, default))
             .Name("Staff")
             .Type<StaffType>();
    }

    public async Task<Customer> ResolveCustomer(IResolverContext context, [Parent] Rental rental, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, Customer>(
            async (ids, ct) =>
            {
                return await dbContext.Customers.Where(x => ids.Contains(x.CustomerId)).ToDictionaryAsync(x => x.CustomerId, x => x, ct);
            })
        .LoadAsync(rental.CustomerId);
    }

    public async Task<Inventory> ResolveInventory(IResolverContext context, [Parent] Rental rental, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<uint, Inventory>(
            async (ids, ct) =>
            {
                return await dbContext.Inventories.Where(x => ids.Contains(x.InventoryId)).ToDictionaryAsync(x => x.InventoryId, x => x, ct);
            })
        .LoadAsync(rental.InventoryId);
    }

    public async Task<Staff> ResolveStaff(IResolverContext context, [Parent] Rental rental, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<byte, Staff>(
            async (ids, ct) =>
            {
                return await dbContext.Staff.Where(x => ids.Contains(x.StaffId)).ToDictionaryAsync(x => x.StaffId, x => x, ct);
            })
        .LoadAsync(rental.StaffId);
    }
}
