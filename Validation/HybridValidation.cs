using GraphQL.Validation;
using GraphQL_API.Data;
using HotChocolate.Language;
using HotChocolate.Validation;
using System.Linq;

namespace GraphQL_API.Validation
{
	public class HybridValidation : IDocumentValidatorRule
	{
		public bool IsCacheable => false;
		public string Name => "HybridValidation";

		private int definitionLimit = 5;
		private int definitionSetLimit = 5;
		private int definitionSetFieldLimit = 15;
		private int _maxDepth = 1;


		public void Validate(IDocumentValidatorContext context, DocumentNode document)
		{
			var doc = document; // query ActorData { actorData(numActors: 5) { actorId firstName lastName lastUpdate }}

			var count = doc.Count;
			var defCount = doc.Definitions.Count;
			var def = doc.Definitions;
			var kind = doc.Kind;
			var fieldsCount = doc.FieldsCount;
			var i = 0;

			if(document.Definitions.Count > definitionLimit)
			{

			}

			foreach (var definition in document.Definitions)
			{
				if (definition is OperationDefinitionNode operation)
				{
					var selections = operation.SelectionSet.Selections;
					var t = operation.SelectionSet;

					if(selections.Count > definitionSetLimit)
					{

					}
					CheckDepth(context, selections, 0);
				}
			}
		}

		private void CheckDepth(IDocumentValidatorContext context, IEnumerable<ISelectionNode> selections, int depth)
		{
			foreach (var selection in selections)
			{
				if (selection is FieldNode field)
				{
					if (depth > _maxDepth)
					{
						var i = 0; // it works!
						//context.Errors.Append(new ValidationError($"Query is too deep - maximum depth {_maxDepth} exceeded."));
					}
					else if (field.SelectionSet != null)
					{
						if (field.SelectionSet.Selections.Count > definitionSetFieldLimit)
						{

						}

						CheckDepth(context, field.SelectionSet.Selections, depth + 1);
					}
				}
			}
		}
	}
}
 