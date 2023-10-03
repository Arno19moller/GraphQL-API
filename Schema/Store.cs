using GraphQL_API.Context;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class StoreType: ObjectType<Store>
{
    protected override void Configure(IObjectTypeDescriptor<Store> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.StoreId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.ManagerStaffId)
           .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.AddressId)
           .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.LastUpdate)
           .Type<NonNullType<DateTimeType>>();

        descriptor.Field<StoreType>(p => ResolveAddress(default, default))
                  .Name("Address")
                  .Type<ListType<AddressType>>();

        descriptor.Field<StoreType>(p => ResolveManagerStaff(default, default))
                 .Name("ManagerStaff")
                 .Type<ListType<StaffType>>();
    }

    public async Task<IReadOnlyList<AddressEntity>> ResolveAddress([Parent] Store store, [Service] SakilaContext sakilaContext)
    {
        return await sakilaContext.Addresses
            .Where(x => x.AddressId == store.AddressId)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Staff>> ResolveManagerStaff([Parent] Store store, [Service] SakilaContext sakilaContext)
    {
        return await sakilaContext.Staff
            .Where(x => x.StaffId == store.ManagerStaffId)
            .ToListAsync();
    }
}
