using HotChocolate.Language;
using HotChocolate.Validation;

namespace GraphQL_API.Validation
{
	public class StaticCostAnalysis : IDocumentValidatorRule
	{
		public bool IsCacheable => false;
		public string Name => "HybridValidation";

		private int _depthLimit = -1;
		private int _definitionLimit = -1;
		private int _definitionSetLimit = -1;
		private int _definitionSetFieldLimit = -1;

		public void Validate(IDocumentValidatorContext context, DocumentNode document)
		{
			if (IsIntrospectionQuery(document.ToString())) return;

			CheckDefinitionLimit(document, context);
			CheckDefinitionSelections(document, context);
		}

		private void CheckDefinitionLimit(DocumentNode document, IDocumentValidatorContext context)
		{
			if (_definitionLimit > -1 && document.Definitions.Count > _definitionLimit)
			{
				AppendError(context, "Too many definitions included in query", document);
			}
		}

		private void CheckDefinitionSelections(DocumentNode document, IDocumentValidatorContext context)
		{
			foreach (var definition in document.Definitions)
			{
				if (definition is OperationDefinitionNode operation)
				{
					var selections = operation.SelectionSet.Selections;

					if (_definitionSetLimit > -1 && selections.Count > _definitionSetLimit)
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
					if (_depthLimit > -1 && depth > _depthLimit)
					{
						AppendError(context, "Query depth too large", selection);
					}
					else if (field.SelectionSet != null)
					{
						if (_definitionSetFieldLimit > -1 && field.SelectionSet.Selections.Count > _definitionSetFieldLimit)
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
									.AddLocation(node)
									.Build();

			context.ReportError(error);
		}

		private bool IsIntrospectionQuery(string query)
		{
			return query.Contains("__schema") ||
				   query.Contains("__type") ||
				   query.Contains("__typename") ||
				   query.Contains("__typeKind") ||
				   query.Contains("__field") ||
				   query.Contains("__inputValue") ||
				   query.Contains("__enumValue") ||
				   query.Contains("__directive");
		}
	}
}