using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.AmazonWorkDocs.Models.Request.Document;

public class CreateDocumentRequest
{
    public FileReference File { get; set; }
    
    [Display("Parent folder ID")]
    public string ParentFolderId { get; set; }
    
    [Display("Document name")]
    public string DocumentName { get; set; }
}