using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonWorkDocs.Models.Request.Document;

public class DocumentRequest
{
    [Display("Document ID")]
    public string DocumentId { get; set; }
}