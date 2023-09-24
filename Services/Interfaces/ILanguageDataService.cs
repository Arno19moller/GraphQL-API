using GraphQL.Entities;

namespace GraphQL_API.Services.Interfaces
{
    public interface ILanguageDataService
    {
        List<Language> GetLanguages(int numLanguages, CancellationToken cancellationToken = default);
    }
}
