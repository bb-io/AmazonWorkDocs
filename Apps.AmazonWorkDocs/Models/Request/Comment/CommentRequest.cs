using Apps.AmazonWorkDocs.Models.Request.Document;
using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonWorkDocs.Models.Request.Comment;

public class CommentRequest : DocumentRequest
{
    [Display("Document version ID")] public string VersionId { get; set; }

    [Display("Comment ID")]
    public string CommentId { get; set; }
}