using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class CountryType : ObjectType<Country>
{
    protected override void Configure(IObjectTypeDescriptor<Country> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.CountryId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.Country1)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field<CountryType>(a => a.ResolveCities(default, default, default))
            .Name("Cities")
            .Type<ListType<CityType>>();
    }

    public async Task<IEnumerable<CityEntity>> ResolveCities(IResolverContext context, [Parent] Country country, [Service] SakilaContext dbContext)
    {
        var stores = await context.BatchDataLoader<ushort, IEnumerable<CityEntity>>(
            async (ids, ct) =>
            {
                var citiesByCountryId = await dbContext.Cities.Where(x => ids.Contains(x.CountryId)).ToListAsync(ct);
                return ids.ToDictionary(id => id, id => citiesByCountryId.Where(store => store.CountryId == id).AsEnumerable());
            })
        .LoadAsync(country.CountryId);

        return stores;
    }
}
