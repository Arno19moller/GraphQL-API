using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class CategoryDataService : ICategoryDataService
    {
        private readonly SakilaContext _dbContext;

        public CategoryDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
