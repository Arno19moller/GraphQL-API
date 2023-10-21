using GraphQL_API.Context;
using GraphQL_API.Data;
using GraphQL_API.Queries;
using GraphQL_API.Services;
using GraphQL_API.Services.Interfaces;
using GraphQL_API.Validation;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Tests
{
	public static class TestServices
	{
		static TestServices()
		{
			//var timeoutString = "00:00:05";
			//var timeout = TimeSpan.Parse(timeoutString);

			//var memoryLimitString = "10000000";
			//var memoryLimitMB = int.Parse(memoryLimitString);

			//var webHostBuilder = new WebHostBuilder()
			//.UseStartup<TestStartup>();

			//webHostBuilder.ConfigureServices(services =>
			//{
			//	services
			//	.AddScoped<IActorDataService, ActorDataService>()
			//	.AddScoped<IAddressDataService, AddressDataService>()
			//	.AddScoped<ICategoryDataService, CategoryDataService>()
			//	.AddScoped<ICityDataService, CityDataService>()
			//	.AddScoped<ICountryDataService, CountryDataService>()
			//	.AddScoped<ICustomerDataService, CustomerDataService>()
			//	.AddScoped<IFilmActorDataService, FilmActorDataService>()
			//	.AddScoped<IFilmCategoryDataService, FilmCategoryDataService>()
			//	.AddScoped<IFilmDataService, FilmDataService>()
			//	.AddScoped<IFilmTextDataService, FilmTextDataService>()
			//	.AddScoped<IInventoryDataService, InventoryDataService>()
			//	.AddScoped<ILanguageDataService, LanguageDataService>()
			//	.AddScoped<IPaymentDataService, PaymentDataService>()
			//	.AddScoped<IRentalDataService, RentalDataService>()
			//	.AddScoped<IStaffDataService, StaffDataService>()
			//	.AddScoped<IStoreDataService, StoreDataService>()
			//	.AddDbContext<SakilaContext>(options => options.UseMySQL("Server=localhost;Port=3306;Database=sakila;User=root;Password=root;"), ServiceLifetime.Transient)
			//	.AddHttpContextAccessor()
			//	.AddGraphQLServer()
			//	.AddQueryType(d => d.Name("Query"))
			//	.AddType<ActorInfoType>()
			//	.AddType<ActorType>()
			//	.AddType<AddressType>()
			//	.AddType<CategoryType>()
			//	.AddType<CityType>()
			//	.AddType<CountryType>()
			//	.AddType<CustomerListType>()
			//	.AddType<CustomerType>()
			//	.AddType<FilmActorType>()
			//	.AddType<FilmCategoryType>()
			//	.AddType<FilmListType>()
			//	.AddType<FilmTextType>()
			//	.AddType<FilmType>()
			//	.AddType<InventoryType>()
			//	.AddType<LanguageType>()
			//	.AddType<NicerButSlowerFilmListType>()
			//	.AddType<PaymentType>()
			//	.AddType<RentalType>()
			//	.AddType<SalesByFilmCategoryType>()
			//	.AddType<SalesByStoreType>()
			//	.AddType<StaffListType>()
			//	.AddType<StaffType>()
			//	.AddType<StoreType>()
			//	.AddTypeExtension<ActorQueries>()
			//	.AddTypeExtension<AddressQueries>()
			//	.AddTypeExtension<CategoryQueries>()
			//	.AddTypeExtension<CityQueries>()
			//	.AddTypeExtension<CountryQueries>()
			//	.AddTypeExtension<CustomerQueries>()
			//	.AddTypeExtension<FilmActorQueries>()
			//	.AddTypeExtension<FilmCategoryQueries>()
			//	.AddTypeExtension<FilmQueries>()
			//	.AddTypeExtension<FilmTextQueries>()
			//	.AddTypeExtension<InventoryQueries>()
			//	.AddTypeExtension<LanguageQueries>()
			//	.AddTypeExtension<PaymentQueries>()
			//	.AddTypeExtension<RentalQueries>()
			//	.AddTypeExtension<StaffQueries>()
			//	.AddTypeExtension<StoreQueries>()
			//	.AddValidationRule<StaticCostAnalysis>();

			//	Services = services
			//	.AddSingleton(sp => new RequestExecutorProxy(
			//		sp.GetRequiredService<IRequestExecutorResolver>(),
			//		Schema.DefaultName))
			//	.BuildServiceProvider();

			//	Executor = Services.GetRequiredService<RequestExecutorProxy>();
			//}).Configure(app =>
			//{
			//	var timeout = TimeSpan.Parse("00:00:03");
			//	var memoryLimitMB = int.Parse("100000");
			//	app.UseMiddleware<DynamicCostAnalysisMiddleware>(timeout, memoryLimitMB);
			//});

			//var Host = webHostBuilder.Build();
			//Host.Start();

			Services = new ServiceCollection()
				.AddScoped<IActorDataService, ActorDataService>()
				.AddScoped<IAddressDataService, AddressDataService>()
				.AddScoped<ICategoryDataService, CategoryDataService>()
				.AddScoped<ICityDataService, CityDataService>()
				.AddScoped<ICountryDataService, CountryDataService>()
				.AddScoped<ICustomerDataService, CustomerDataService>()
				.AddScoped<IFilmActorDataService, FilmActorDataService>()
				.AddScoped<IFilmCategoryDataService, FilmCategoryDataService>()
				.AddScoped<IFilmDataService, FilmDataService>()
				.AddScoped<IFilmTextDataService, FilmTextDataService>()
				.AddScoped<IInventoryDataService, InventoryDataService>()
				.AddScoped<ILanguageDataService, LanguageDataService>()
				.AddScoped<IPaymentDataService, PaymentDataService>()
				.AddScoped<IRentalDataService, RentalDataService>()
				.AddScoped<IStaffDataService, StaffDataService>()
				.AddScoped<IStoreDataService, StoreDataService>()
				.AddDbContext<SakilaContext>(options => options.UseMySQL("Server=localhost;Port=3306;Database=sakila;User=root;Password=root;"), ServiceLifetime.Transient)
				.AddHttpContextAccessor()
				.AddGraphQLServer()
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
				.AddValidationRule<StaticCostAnalysis>()
				.UseField<DynamicCostAnalysisMiddleware>()
				.Services
				.Configure<DynamicCostAnalysisMiddlewareOptions>(options =>
				{
					options.Timeout = TimeSpan.FromSeconds(30); // Set your desired timeout
					options.MemoryLimitMB = 10000; // Set your desired memory limit
				})
				.AddSingleton(sp => new RequestExecutorProxy(
					sp.GetRequiredService<IRequestExecutorResolver>(),
					Schema.DefaultName))
				.BuildServiceProvider();

			Executor = Services.GetRequiredService<RequestExecutorProxy>();
		}

		public static IServiceProvider Services { get; set; }
		public static RequestExecutorProxy Executor { get; set; }

		public static async Task<string> ExecuteRequestAsync(Action<IQueryRequestBuilder> configureRequest, CancellationToken cancellationToken = default)
		{
			await using var scope = Services.CreateAsyncScope();

			var requestBuilder = new QueryRequestBuilder();
			requestBuilder.SetServices(scope.ServiceProvider);
			configureRequest(requestBuilder);
			var request = requestBuilder.Create();

			await using var result = await Executor.ExecuteAsync(request, cancellationToken);
			result.ExpectQueryResult();

			return result.ToJson();
		}
	}
}