using GraphQL_API.Context;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data;

public class FilmActorType : ObjectType<FilmActor>
{
    protected override void Configure(IObjectTypeDescriptor<FilmActor> descriptor)
    {
        base.Configure(descriptor);

        descriptor.Field(a => a.ActorId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.FilmId)
            .Type<NonNullType<IdType>>();

        descriptor.Field(a => a.LastUpdate)
            .Type<NonNullType<DateTimeType>>();

        descriptor.Field<FilmActorType>(p => ResolveActor(default, default, default))
            .Name("Actor")
            .Type<ActorType>();

        descriptor.Field<FilmActorType>(p => ResolveFilm(default, default, default))
            .Name("Film")
            .Type<FilmType>();
    }

    public virtual Actor Actor { get; set; } = null!;

    public async Task<Actor> ResolveActor(IResolverContext context, [Parent] FilmActor filmCategory, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, Actor>(
            async (ids, ct) =>
            {
                return await dbContext.Actors.Where(x => ids.Contains(x.ActorId)).ToDictionaryAsync(x => x.ActorId, x => x, ct);
            })
        .LoadAsync(filmCategory.ActorId);
    }

    public async Task<Film> ResolveFilm(IResolverContext context, [Parent] FilmActor filmCategory, [Service] SakilaContext dbContext)
    {
        return await context.BatchDataLoader<ushort, Film>(
            async (ids, ct) =>
            {
                return await dbContext.Films.Where(x => ids.Contains(x.FilmId)).ToDictionaryAsync(x => x.FilmId, x => x, ct);
            })
        .LoadAsync(filmCategory.FilmId);
    }
}
