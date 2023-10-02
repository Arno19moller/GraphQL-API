using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface ICategoryDataService
    {
        List<Category> GetCategories(int numCategories, CancellationToken cancellationToken = default);
    }
}
