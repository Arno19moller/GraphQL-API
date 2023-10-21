using GraphQL_API.Context;
using GraphQL_API.Data;
using GraphQL_API.Queries;
using GraphQL_API.Services;
using GraphQL_API.Services.Interfaces;
using GraphQL_API.Validation;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Tests
{
	public class TestStartup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddScoped<IActorDataService, ActorDataService>();
			services.AddScoped<IAddressDataService, AddressDataService>();
			services.AddScoped<ICategoryDataService, CategoryDataService>();
			services.AddScoped<ICityDataService, CityDataService>();
			services.AddScoped<ICountryDataService, CountryDataService>();
			services.AddScoped<ICustomerDataService, CustomerDataService>();
			services.AddScoped<IFilmActorDataService, FilmActorDataService>();
			services.AddScoped<IFilmCategoryDataService, FilmCategoryDataService>();
			services.AddScoped<IFilmDataService, FilmDataService>();
			services.AddScoped<IFilmTextDataService, FilmTextDataService>();
			services.AddScoped<IInventoryDataService, InventoryDataService>();
			services.AddScoped<ILanguageDataService, LanguageDataService>();
			services.AddScoped<IPaymentDataService, PaymentDataService>();
			services.AddScoped<IRentalDataService, RentalDataService>();
			services.AddScoped<IStaffDataService, StaffDataService>();
			services.AddScoped<IStoreDataService, StoreDataService>();

			services
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
				.AddValidationRule<StaticCostAnalysis>();
		}

		public void Configure(IApplicationBuilder app)
		{
			var timeoutString = "00:00:05";
			var timeout = TimeSpan.Parse(timeoutString!);

			var memoryLimitString = "100000000";
			var memoryLimitMB = int.Parse(memoryLimitString);

			app.UseMiddleware<DynamicCostAnalysisMiddleware>(timeout, memoryLimitMB);

			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapGraphQL("/graphql").WithOptions(new GraphQLServerOptions
				{
					EnableBatching = true
				});
			});
		}
	}
}
