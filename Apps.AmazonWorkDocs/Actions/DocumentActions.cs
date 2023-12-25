using System.Net.Mime;
using Amazon.WorkDocs.Utils;
using Apps.AmazonWorkDocs.Invocables;
using Apps.AmazonWorkDocs.Models.Entities;
using Apps.AmazonWorkDocs.Models.Request.Document;
using Apps.AmazonWorkDocs.Models.Response;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;

namespace Apps.AmazonWorkDocs.Actions;

[ActionList]
public class DocumentActions : AmazonWorkDocsInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public DocumentActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient;
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

    [Action("Get document content", Description = "Get content of a specific document")]
    public async Task<FileResponse> GetDocumentContent([ActionParameter] DocumentVersionRequest doc)
    {
        using var contentManager = new ContentManager(new()
        {
            WorkDocsClient = Client
        });

        var response = await contentManager.GetDocumentStreamAsync(new()
        {
            DocumentId = doc.DocumentId,
            VersionId = doc.VersionId
        });

        var file = await _fileManagementClient.UploadAsync(response.Stream, response.DocumentId,
            MediaTypeNames.Application.Octet);
        
        return new()
        {
            File = file
        };
    }

    [Action("Create document", Description = "Create a new document")]
    public async Task<DocumentEntity> CreateDocument([ActionParameter] CreateDocumentRequest input)
    {
        using var contentManager = new ContentManager(new()
        {
            WorkDocsClient = Client
        });

        var fileStream = await _fileManagementClient.DownloadAsync(input.File);
        var response = await contentManager.UploadDocumentStreamAsync(new()
        {
            Stream = fileStream,
            ParentFolderId = input.ParentFolderId,
            DocumentName = input.DocumentName,
            ContentType = input.File.ContentType
        });

        return await GetDocument(new()
        {
            DocumentId = response.DocumentId
        });
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