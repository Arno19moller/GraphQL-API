using GraphQL_API.Context;
using GraphQL_API.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Services.Interfaces
{
    public class LanguageDataService: ILanguageDataService
    {
        private readonly SakilaContext _dbContext;

        public LanguageDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Language> GetLanguages(int numLanguages, CancellationToken cancellationToken = default)
        {
            return _dbContext.Languages
                .Include(x => x.FilmLanguages)
                .Include(x => x.FilmOriginalLanguages)
                .AsNoTracking()
                .Take(numLanguages)
                .ToList();
        }
    }
}
