using GraphQL.Data;
using GraphQL.Entities;

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
            throw new NotImplementedException();
        }
    }
}
