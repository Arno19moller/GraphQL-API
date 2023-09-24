using GraphQL_API.Services;
using System;
using System.Collections.Generic;

namespace GraphQL.Entities;

public partial class Actor
{
	[GraphQLType(typeof(IntType))]
	public ushort ActorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [GraphQLType(typeof(DateTimeType))]
    public DateTime LastUpdate { get; set; }

	//[GraphQLIgnore]
	public virtual ICollection<FilmActor>? FilmActors { get; set; } = new List<FilmActor>();
}

//public class ActorType : ObjectType<Actor>
//{
//	protected override void Configure(IObjectTypeDescriptor<Actor> descriptor)
//	{
//		descriptor.BindFields(BindingBehavior.Explicit);
//		//descriptor.BindFieldsExplicitly();

//		descriptor.Field(f => f.ActorId);
//		descriptor.Field(f => f.FirstName);
//		descriptor.Field(f => f.LastName);
//		descriptor.Field(f => f.LastUpdate);
//		descriptor.Field(f => f.FilmActors).ResolveWith<FooResolvers>(x => x.GetFoo(default, default));
//	}
//}

//public class FooResolvers
//{
//	public ICollection<FilmActor> GetFoo(string arg, [Service] IActorDataService service)
//	{
//		return service.GetFilmActors();
//	}
//}