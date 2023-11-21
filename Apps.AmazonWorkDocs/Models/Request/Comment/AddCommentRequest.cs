using Apps.AmazonWorkDocs.Models.Request.Document;
using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonWorkDocs.Models.Request.Comment;

public class AddCommentRequest : DocumentRequest
{
    [Display("Document version ID")] public string VersionId { get; set; }

    public string Comment { get; set; }

    [Display("Notify collaborators")] public bool? NotifyCollaborators { get; set; }

    [Display("Is comment private")] public bool? IsCommentPrivate { get; set; }
}