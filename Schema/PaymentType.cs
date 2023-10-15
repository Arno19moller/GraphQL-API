using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class PaymentType : ObjectType<Payment>
{
    protected override void Configure(IObjectTypeDescriptor<Payment> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.PaymentId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.CustomerId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.StaffId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.RentalId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Amount)
            .Type<NonNullType<IntType>>();

        descriptor.Field(a => a.PaymentDate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        ////
        descriptor.Field<PaymentType>(a => a.ResolveCustomer(default, default, default))
             .Name("Customer")
             .Type<CustomerType>();

        descriptor.Field<PaymentType>(a => a.ResolveRental(default, default, default))
             .Name("Rental")
             .Type<RentalType>();

        descriptor.Field<PaymentType>(a => a.ResolveStaff(default, default, default))
             .Name("Staff")
             .Type<StaffType>();
    }

    public async Task<Customer> ResolveCustomer(IResolverContext context, [Parent] Payment payment, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, Customer>(
            async (ids, ct) =>
            {
                return await dbContext.Customers.Where(x => ids.Contains(x.CustomerId)).ToDictionaryAsync(x => x.CustomerId, x => x, ct);
            })
        .LoadAsync(payment.CustomerId);
    }

    public async Task<Rental?> ResolveRental(IResolverContext context, [Parent] Payment payment, [Service] SakilaContext dbContext)
    {
        return (Rental?)await context.BatchDataLoader<int, Rental>(
            async (ids, ct) =>
            {
                return await dbContext.Rentals.Where(x => ids.Contains(x.RentalId)).ToDictionaryAsync(x => x.RentalId, x => x, ct);
            })
        .LoadAsync(payment.RentalId);
    }

    public async Task<Staff> ResolveStaff(IResolverContext context, [Parent] Payment payment, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<byte, Staff>(
            async (ids, ct) =>
            {
                return await dbContext.Staff.Where(x => ids.Contains(x.StaffId)).ToDictionaryAsync(x => x.StaffId, x => x, ct);
            })
        .LoadAsync(payment.StaffId);
    }
}
