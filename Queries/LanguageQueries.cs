using GraphQL_API.Data;
using GraphQL_API.Services.Interfaces;
using HotChocolate;

namespace GraphQL_API.Queries
{
    [ExtendObjectType(Name = "Query")]
	public class LanguageQueries
	{
        public async Task<List<Language>> GetlanguageData(int numLanguages, [Service] ILanguageDataService languageService, CancellationToken cancellationToken)
        {
            return languageService.GetLanguages(numLanguages, cancellationToken);
        }
    }
}
