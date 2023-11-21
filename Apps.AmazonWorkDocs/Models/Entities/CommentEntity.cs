using Amazon.WorkDocs.Model;
using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonWorkDocs.Models.Entities;

public class CommentEntity
{
    [Display("Comment ID")]
    public string CommentId { get; set; }

    [Display("Contributor")]
    public UserEntity Contributor { get; set; }

    [Display("Created date")]
    public DateTime? CreatedTimestamp { get; set; }

    [Display("Parent ID")]
    public string ParentId { get; set; }

    [Display("Recipient ID")]
    public string RecipientId { get; set; }

    [Display("Status")]
    public string Status { get; set; }

    [Display("Text")]
    public string Text { get; set; }

    [Display("Thread ID")]
    public string ThreadId { get; set; }

    [Display("Visibility")]
    public string Visibility { get; set; }

    public CommentEntity(Comment comment)
    {
        CommentId = comment.CommentId;
        Contributor = new(comment.Contributor);
        CreatedTimestamp = comment.CreatedTimestamp;
        ParentId = comment.ParentId;
        RecipientId = comment.RecipientId;
        Status = comment.Status;
        Text = comment.Text;
        ThreadId = comment.ThreadId;
        Visibility = comment.Visibility;
    }
}