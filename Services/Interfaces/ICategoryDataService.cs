using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface ICategoryDataService
    {
        List<Category> GetCategories(int numCategories, CancellationToken cancellationToken = default);
    }
}
