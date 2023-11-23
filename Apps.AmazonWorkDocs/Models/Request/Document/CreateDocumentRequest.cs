using Blackbird.Applications.Sdk.Common;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.AmazonWorkDocs.Models.Request.Document;

public class CreateDocumentRequest
{
    public File File { get; set; }
    
    [Display("Parent folder ID")]
    public string ParentFolderId { get; set; }
    
    [Display("Document name")]
    public string DocumentName { get; set; }
}