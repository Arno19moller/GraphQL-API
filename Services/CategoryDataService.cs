using GraphQL.Data;
using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public class CategoryDataService : ICategoryDataService
    {
        private readonly SakilaContext _dbContext;

        public CategoryDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetCategories(int numCategories, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
