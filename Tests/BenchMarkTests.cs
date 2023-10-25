using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Text;
using Xunit;
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
		}

		[Theory]
		//[InlineData("query ActorData { actorData(numActors: 5) { actorId firstName } }")]
		//[InlineData("query ActorData { actorData(numActors: 1000) { actorId firstName } }")]
		//[InlineData("query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate } } ")]
		//[InlineData("query ActorData { actorData(numActors: 1000) { actorId firstName lastName lastUpdate } } ")]
		//[InlineData("query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate filmActors { actorId filmId lastUpdate } } }")]
		//[InlineData("query ActorData { actorData(numActors: 1000) { actorId firstName lastName lastUpdate filmActors { actorId filmId lastUpdate } } }")]
		//[InlineData("query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate filmActors { actorId filmId lastUpdate film { filmId title description releaseYear languageId originalLanguageId rentalDuration rentalRate length replacementCost rating specialFeatures lastUpdate } } } } ")]
		//[InlineData("query ActorData { actorData(numActors: 1000) { actorId firstName lastName lastUpdate filmActors { actorId filmId lastUpdate film { filmId title description releaseYear languageId originalLanguageId rentalDuration rentalRate length replacementCost rating specialFeatures lastUpdate } } } } ")]
		[InlineData("query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate filmActors { actorId filmId lastUpdate film { inventories { inventoryId rentals { rentalId } } } } } } ")]
		[InlineData("query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate filmActors { actorId filmId lastUpdate film { inventories { inventoryId rentals { rentalId rentalDate } } } } } } ")]
		[InlineData("query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate filmActors { actorId filmId lastUpdate film { inventories { inventoryId rentals { rentalId inventoryId} } } } } } ")]
		[InlineData("query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate filmActors { actorId filmId lastUpdate film { inventories { inventoryId rentals { rentalId customerId} } } } } } ")]
		[InlineData("query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate filmActors { actorId filmId lastUpdate film { inventories { inventoryId rentals { rentalId returnDate} } } } } } ")]
		public async Task FilmActorsQuery_ReturnsSuccessStatusCode(string query)
		{
			// Act
			var response = await _client.PostAsync("/graphql", new StringContent(
				JsonConvert.SerializeObject(new
				{
					query
				}),
				Encoding.UTF8,
				"application/json"));

			// Assert
			response.EnsureSuccessStatusCode();
		}
	}
}