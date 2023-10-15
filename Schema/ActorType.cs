using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class ActorType : ObjectType<Actor>
{
    protected override void Configure(IObjectTypeDescriptor<Actor> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.ActorId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.FirstName)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastName)
            .Type<NonNullType<StringType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field(a => a.ActorId)
            .Type<NonNullType<IdType>>();

		descriptor.Field<ActorType>(a => a.ResolveFilmActor(default, default, default))
			.Name("filmActors")
			.Type<ListType<FilmActorType>>();
	}

	public async Task<IEnumerable<FilmActor>> ResolveFilmActor(IResolverContext context, [Parent] Actor actor, [Service] SakilaContext dbContext)
	{
		return await context.BatchDataLoader<ushort, IEnumerable<FilmActor>>(
			async (ids, ct) =>
			{
				var filmActorByActorId = await dbContext.FilmActors.Where(x => ids.Contains(x.ActorId)).ToListAsync(ct);
				return ids.ToDictionary(id => id, id => filmActorByActorId.Where(filmActor => filmActor.ActorId == id).AsEnumerable());
			})
		.LoadAsync(actor.ActorId);
	}
}