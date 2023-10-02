using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class CategoryQueries
    {
        public async Task<List<CategoryType>> GetCategoryData(int numCategories, [Service] ICategoryDataService categoryService, CancellationToken cancellationToken)
        {
            return categoryService.GetCategories(numCategories, cancellationToken);
        }
    }
}
