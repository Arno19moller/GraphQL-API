using GraphQL_API.Context;
using GraphQL_API.Data;
using GraphQL_API.Queries;
using GraphQL_API.Services;
using GraphQL_API.Services.Interfaces;
using GraphQL_API.Validation;
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
		ConfigureMiddleware(app, builder);
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

		serviceCollection.AddDbContext<SakilaContext>(options => options.UseMySQL("Server=localhost;Port=3306;Database=sakila;User=root;Password=root;"), ServiceLifetime.Transient);
		serviceCollection.AddHttpContextAccessor();
	}

	private static void AddGraphQL(IServiceCollection serviceCollection)
	{
		serviceCollection.AddGraphQLServer()
						 .AddQueryType(d => d.Name("Query"))
						 .AddType<ActorInfoType>()
						 .AddType<ActorType>()
						 .AddType<AddressType>()
						 .AddType<CategoryType>()
						 .AddType<CityType>()
						 .AddType<CountryType>()
						 .AddType<CustomerListType>()
						 .AddType<CustomerType>()
						 .AddType<FilmActorType>()
						 .AddType<FilmCategoryType>()
						 .AddType<FilmListType>()
						 .AddType<FilmTextType>()
						 .AddType<FilmType>()
						 .AddType<InventoryType>()
						 .AddType<LanguageType>()
						 .AddType<NicerButSlowerFilmListType>()
						 .AddType<PaymentType>()
						 .AddType<RentalType>()
						 .AddType<SalesByFilmCategoryType>()
						 .AddType<SalesByStoreType>()
						 .AddType<StaffListType>()
						 .AddType<StaffType>()
						 .AddType<StoreType>()
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
						 .AddTypeExtension<StoreQueries>()
						 .AddValidationRule<StaticCostAnalysis>();
	}

	private static void ConfigureMiddleware(WebApplication app, WebApplicationBuilder builder)
	{
		var timeoutString = builder.Configuration.GetValue<string>("Performance:Timeout");
		var timeout = TimeSpan.Parse(timeoutString!);

		var memoryLimitString = builder.Configuration.GetValue<string>("Performance:MemoryLimitMB");
		var memoryLimitMB = int.Parse(memoryLimitString);

		app.UseMiddleware<DynamicCostAnalysisMiddleware>(timeout, memoryLimitMB);
	}

	private static void ConfigureApp(WebApplication app)
	{
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error");
			app.UseHsts();
		}

		app.MapGraphQL().WithOptions(new GraphQLServerOptions
		{
			EnableBatching = true
		});
		app.UseRouting();
		app.UseAuthorization();
		app.Run();
	}
}