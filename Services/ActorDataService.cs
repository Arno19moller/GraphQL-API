﻿using GraphQL.Data;
using GraphQL.Entities;
using GraphQL_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services
{
    public class ActorDataService: IActorDataService
	{
		private readonly SakilaContext _dbContext;

		public ActorDataService(SakilaContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Actor> GetActorsAsync(int numActors, CancellationToken cancellationToken = default)
		{
			return _dbContext.Actors.Include(x => x.FilmActors)
							 .AsNoTracking()
							 .Take(numActors)
							 .ToList();
		}
	}
}
