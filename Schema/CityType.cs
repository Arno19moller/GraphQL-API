using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class CityType : ObjectType<CityEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CityEntity> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.CityId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.City)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.CountryId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field<CityType>(a => a.ResolveCountry(default, default, default))
            .Name("Country")
            .Type<CountryType>();
    }

    public async Task<Country> ResolveCountry(IResolverContext context, [Parent] CityEntity staff, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, Country>(
            async (ids, ct) =>
            {
                return await dbContext.Countries.Where(x => ids.Contains(x.CountryId)).ToDictionaryAsync(x => x.CountryId, x => x, ct);
            })
        .LoadAsync(staff.CountryId);
    }
}
