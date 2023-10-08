//using GraphQL.Validation;

using GraphQL.Validation;
using HotChocolate.Language;
using HotChocolate.Validation;

namespace GraphQL_API.Validation
{
	public class HybridValidation : IDocumentValidatorRule
	{
		public bool IsCacheable => false;
		public string Name => "HybridValidation";


		public void Validate(IDocumentValidatorContext context, DocumentNode document)
		{
			Console.Write("HybridValidation: ");
			Console.WriteLine(context.ContextData);
			//Console.WriteLine(document);
		}
	}
}
