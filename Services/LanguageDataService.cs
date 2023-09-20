using GraphQL.Data;

namespace GraphQL_API.Services.Interfaces
{
    public class LanguageDataService: ILanguageDataService
    {
        private readonly SakilaContext _dbContext;

        public LanguageDataService(SakilaContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
