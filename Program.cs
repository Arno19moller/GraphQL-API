using GraphQL_API.Context;
using GraphQL_API.Queries;
using GraphQL_API.Services;
using GraphQL_API.Services.Interfaces;
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
		serviceCollection.AddScoped<IAddressDataService, AddressDataService>();
		serviceCollection.AddScoped<ICategoryDataService, CategoryDataService>();
		serviceCollection.AddScoped<ICityDataService, CityDataService>();
		serviceCollection.AddScoped<ICountryDataService, CountryDataService>();
		serviceCollection.AddScoped<ICustomerDataService, CustomerDataService>();
		serviceCollection.AddScoped<IFilmActorDataService, FilmActorDataService>();
		serviceCollection.AddScoped<IFilmCategoryDataService, FilmCategoryDataService>();
		serviceCollection.AddScoped<IFilmDataService, FilmDataService>();
		serviceCollection.AddScoped<IFilmTextDataService, FilmTextDataService>();
		serviceCollection.AddScoped<IInventoryDataService, InventoryDataService>();
		serviceCollection.AddScoped<ILanguageDataService, LanguageDataService>();
		serviceCollection.AddScoped<IPaymentDataService, PaymentDataService>();
		serviceCollection.AddScoped<IRentalDataService, RentalDataService>();
		serviceCollection.AddScoped<IStaffDataService, StaffDataService>();
		serviceCollection.AddScoped<IStoreDataService, StoreDataService>();

		serviceCollection.AddDbContext<SakilaContext>(options => options.UseMySQL(builder.Configuration.GetValue<string>("DefaultConnection")), ServiceLifetime.Transient);
		serviceCollection.AddHttpContextAccessor();
	}

	private static void AddGraphQL(IServiceCollection serviceCollection)
	{
		serviceCollection.AddGraphQLServer()
						 .AddQueryType(d => d.Name("Query"))
						 .AddTypeExtension<ActorQueries>()
						 .AddTypeExtension<AddressQueries>()
						 .AddTypeExtension<CategoryQueries>()
						 .AddTypeExtension<CityQueries>()
						 .AddTypeExtension<CountryQueries>()
						 .AddTypeExtension<CustomerQueries>()
						 .AddTypeExtension<FilmActorQueries>()
						 .AddTypeExtension<FilmCategoryQueries>()
						 .AddTypeExtension<FilmQueries>()
						 .AddTypeExtension<FilmTextQueries>()
						 .AddTypeExtension<InventoryQueries>()
						 .AddTypeExtension<LanguageQueries>()
						 .AddTypeExtension<PaymentQueries>()
						 .AddTypeExtension<RentalQueries>()
						 .AddTypeExtension<StaffQueries>()
						 .AddTypeExtension<StoreQueries>();
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
		//app.MapControllers();
		//app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL-API");
		});
		//app.UseHttpsRedirection();
		//app.UseStaticFiles();
		app.UseRouting();
		app.UseAuthorization();
		app.Run();
	}
}