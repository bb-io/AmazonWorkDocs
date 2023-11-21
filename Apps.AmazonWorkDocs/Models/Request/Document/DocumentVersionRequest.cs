using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonWorkDocs.Models.Request.Document;

public class DocumentVersionRequest : DocumentRequest
{
    [Display("Document version ID")] public string VersionId { get; set; }
}