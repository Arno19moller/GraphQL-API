using GraphQL_API.Context;
using GraphQL_API.Data;
using GraphQL_API.Queries;
using GraphQL_API.Services.Interfaces;
using GraphQL_API.Services;
using GraphQL_API.Validation;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
//using Snapshooter.Xunit;
using System.Text;
using Xunit;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;

namespace GraphQL_API.Tests
{
	public class BenchMarkTests : IClassFixture<WebApplicationFactory<TestStartup>>
	{
		private readonly TestServer _server;
		private readonly HttpClient _client;

		public BenchMarkTests()
		{

			var webHostBuilder = new WebHostBuilder()
			.UseStartup<TestStartup>();

			_server = new TestServer(webHostBuilder);
			_client = _server.CreateClient();





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

			//	TestServices.Services = services
			//	.AddSingleton(sp => new RequestExecutorProxy(
			//		sp.GetRequiredService<IRequestExecutorResolver>(),
			//		Schema.DefaultName))
			//	.BuildServiceProvider();

			//	TestServices.Executor = TestServices.Services.GetRequiredService<RequestExecutorProxy>();
			//}).Configure(app =>
			//{
			//	var timeout = TimeSpan.Parse("00:00:03");
			//	var memoryLimitMB = int.Parse("100000");
			//	app.UseMiddleware<DynamicCostAnalysisMiddleware>(timeout, memoryLimitMB);
			//});
		}

		[Fact]
		public async Task SchemaChangeTest()
		{
			var schema = await TestServices.Executor.GetSchemaAsync(default);
			//schema.ToString().MatchSnapshot();
		}

		[Fact]
		public async Task RequestTest()
		{
			var result = await TestServices.ExecuteRequestAsync(b => 
			b.SetQuery("query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate }}"));
			var i = result;
			//result.MatchSnapshot();
		}

		[Fact]
		public async Task Request2Test()
		{
			//var message = new HttpRequestMessage()
			//{
			//	RequestUri = new Uri("/graphql/"),
			//	Method = HttpMethod.Post,
			//	Content = new StringContent("query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate }}", Encoding.UTF8, "application/json"),
			//};
			//var res = await _client.SendAsync(message);


			var response = await _client.PostAsync("/graphql", new StringContent(
			"query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate }}",
			Encoding.UTF8,
			"application/json"));

			// Assert
			response.EnsureSuccessStatusCode();

			var i = response;
		}

		[Fact]
		public async Task FilmActorsQuery_ReturnsSuccessStatusCode()
		{
			// Act
			var response = await _client.PostAsync("/graphql", new StringContent(
				JsonConvert.SerializeObject(new
				{
					query = @"{
                    filmActors(numFilmActors: 1){
                        actorId,
                        filmId,
                        film {
                            title,
                            rentalRate
                        },
                        actor {
                            firstName,
                            lastName,
                            filmActors {
                                actorId
                            }
                        }
                    }
                }"
				}),
				Encoding.UTF8,
				"application/json"));

			// Assert
			response.EnsureSuccessStatusCode();
		}
	}
}
