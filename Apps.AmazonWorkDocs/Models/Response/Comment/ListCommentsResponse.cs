using Apps.AmazonWorkDocs.Models.Entities;

namespace Apps.AmazonWorkDocs.Models.Response.Comment;

public record ListCommentsResponse(List<CommentEntity> Comments);