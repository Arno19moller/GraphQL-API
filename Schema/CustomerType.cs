using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class CustomerType : ObjectType<Customer>
{
    protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.CustomerId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.StoreId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.FirstName)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastName)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Email)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.AddressId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Active)
            .Type<NonNullType<BooleanType>>();

        descriptor.Field(a => a.CreateDate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field<CustomerType>(a => a.ResolveAddress(default, default, default))
            .Name("Store")
            .Type<StoreType>();

        descriptor.Field<CustomerType>(a => a.ResolveAddress(default, default, default))
             .Name("Address")
             .Type<AddressType>();
    }


    public async Task<Store> ResolveStore(IResolverContext context, [Parent] Customer customer, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<byte, Store>(
            async (ids, ct) =>
            {
                return await dbContext.Stores.Where(x => ids.Contains(x.StoreId)).ToDictionaryAsync(x => x.StoreId, x => x, ct);
            })
        .LoadAsync(customer.StoreId);
    }

    public async Task<AddressEntity> ResolveAddress(IResolverContext context, [Parent] Customer customer, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, AddressEntity>(
            async (ids, ct) =>
            {
                return await dbContext.Addresses.Where(x => ids.Contains(x.AddressId)).ToDictionaryAsync(x => x.AddressId, x => x, ct);
            })
        .LoadAsync(customer.AddressId);
    }
}
