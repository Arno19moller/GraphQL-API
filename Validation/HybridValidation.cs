using HotChocolate.Language;
using HotChocolate.Validation;

namespace GraphQL_API.Validation
{
	public class HybridValidation : IDocumentValidatorRule
	{
		public bool IsCacheable => false;
		public string Name => "HybridValidation";

		private int _depthLimit = 1;
		private int _definitionLimit = 1;
		private int _definitionSetLimit = 1;
		private int _definitionSetFieldLimit = 1;

		public void Validate(IDocumentValidatorContext context, DocumentNode document)
		{
			if (document.Definitions.Count > _definitionLimit)
			{
				AppendError(context, "Too many definitions included in query", document);
			}

			foreach (var definition in document.Definitions)
			{
				if (definition is OperationDefinitionNode operation)
				{
					var selections = operation.SelectionSet.Selections;

					if (selections.Count > _definitionSetLimit)
					{
						AppendError(context, "Too many definition sets included in query", definition);
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
					if (depth > _depthLimit)
					{
						AppendError(context, "Query depth too large", selection);
					}
					else if (field.SelectionSet != null)
					{
						if (field.SelectionSet.Selections.Count > _definitionSetFieldLimit)
						{
							AppendError(context, "Too many fields in definition sets included in query", field.SelectionSet);
						}

						CheckDepth(context, field.SelectionSet.Selections, depth + 1);
					}
				}
			}
		}

		private void AppendError(IDocumentValidatorContext context, string errorMessage, ISyntaxNode node)
		{
			var error = ErrorBuilder.New()
									.SetMessage(errorMessage)
									//.SetCode("MY_ERROR_CODE")
									//.SetPath(/* the path to the field or operation that caused the error */)
									.AddLocation(node)
									//.SetExtension("exception", new Exception("Too many definitions included in query"))
									.Build();

			context.ReportError(error);
		}
	}
}
