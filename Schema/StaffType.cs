using GraphQL_API.Context;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GraphQL_API.Data;

public class StaffType : ObjectType<Staff>
{
    protected override void Configure(IObjectTypeDescriptor<Staff> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.StaffId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.FirstName)
           .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastName)
           .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.AddressId)
           .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Picture)
           .Type<NonNullType<ByteArrayType>>();

        descriptor.Field(a => a.Email)
           .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.StoreId)
           .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Active)
           .Type<NonNullType<BooleanType>>();

        descriptor.Field(a => a.Username)
           .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.Password)
           .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastUpdate)
           .Type<NonNullType<DateTimeType>>();

        descriptor.Field<StaffType>(a => a.ResolveAddress(default, default, default))
             .Name("Address")
             .Type<AddressType>();

        descriptor.Field<StaffType>(a => a.ResolveStore(default, default, default))
             .Name("Store")
             .Type<StoreType>();
    }

    public async Task<AddressEntity> ResolveAddress(IResolverContext context, [Parent] Staff staff, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, AddressEntity>(
            async (ids, ct) =>
            {
                return await dbContext.Addresses.Where(x => ids.Contains(x.AddressId)).ToDictionaryAsync(x => x.AddressId, x => x, ct);
            })
        .LoadAsync(staff.AddressId);
    }

    public async Task<Store> ResolveStore(IResolverContext context, [Parent] Staff staff, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<byte, Store>(
            async (ids, ct) =>
            {
                return await dbContext.Stores.Where(x => ids.Contains(x.StoreId)).ToDictionaryAsync(x => x.StoreId, x => x, ct);
            })
        .LoadAsync(staff.StoreId);
    }
}