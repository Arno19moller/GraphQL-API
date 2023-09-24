using GraphQL.Data;
using GraphQL.Entities;
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

        public List<Category> GetCategories(int numCategories, CancellationToken cancellationToken = default)
        {
            return _dbContext.Categories.Include(x => x.FilmCategories)
                             .AsNoTracking()
                             .Take(numCategories)
                             .ToList();
        }
    }
}
