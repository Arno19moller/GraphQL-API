using GraphQL_API.Context;
using GraphQL_API.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class CategoryDataService : ICategoryDataService
    {
        private readonly SakilaContext _dbContext;

        public CategoryDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CategoryType> GetCategories(int numCategories, CancellationToken cancellationToken = default)
        {
            return _dbContext.Categories.Include(x => x.FilmCategories)
                             .AsNoTracking()
                             .Take(numCategories)
                             .ToList();
        }
    }
}
