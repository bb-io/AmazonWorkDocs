using Apps.AmazonWorkDocs.Invocables;
using Apps.AmazonWorkDocs.Models.Entities;
using Apps.AmazonWorkDocs.Models.Request.Document;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonWorkDocs.Actions;

[ActionList]
public class DocumentActions : AmazonWorkDocsInvocable
{
    public DocumentActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Get document", Description = "Get details of a specific document")]
    public async Task<DocumentEntity> GetDocument([ActionParameter] DocumentRequest doc)
    {
        var response = await Client.GetDocumentAsync(new()
        {
            DocumentId = doc.DocumentId
        });
        return new(response.Metadata);
    }

    [Action("Delete document", Description = "Delete specific")]
    public Task DeleteDocument([ActionParameter] DocumentRequest doc)
    {
        return Client.DeleteDocumentAsync(new()
        {
            DocumentId = doc.DocumentId
        });
    }
}