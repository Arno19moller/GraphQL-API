using GraphQL.Data;
using GraphQL.Entities;
using GraphQL_API.Queries;
using GraphQL_API.Services;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		IServiceCollection serviceCollection = builder.Services;
		AddServices(serviceCollection, builder);
		AddGraphQL(serviceCollection);

		// Configure app
		var app = builder.Build();
		ConfigureApp(app);
	}

	private static void AddServices(IServiceCollection serviceCollection, WebApplicationBuilder builder)
	{
		serviceCollection.AddControllers();
		serviceCollection.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "GraphQL",
				Version = "v1",
				Description = "API to query data",
			});
		});

		serviceCollection.AddScoped<IActorDataService, ActorDataService>();
		serviceCollection.AddDbContext<SakilaContext>(options => options.UseMySQL(builder.Configuration.GetValue<string>("DefaultConnection")));
		serviceCollection.AddHttpContextAccessor();
	}

	private static void AddGraphQL(IServiceCollection serviceCollection)
	{
		serviceCollection.AddGraphQLServer()
						 .AddQueryType(d => d.Name("Query"))
						 .AddTypeExtension<ActorQueries>();
	}

	private static void ConfigureApp(WebApplication app)
	{
		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.MapGraphQL().WithOptions(new GraphQLServerOptions
		{
			EnableBatching = true
		}); ;
		app.MapControllers();
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL-API");
		});
		app.UseHttpsRedirection();
		app.UseStaticFiles();
		app.UseRouting();
		app.UseAuthorization();
		app.Run();
	}
}