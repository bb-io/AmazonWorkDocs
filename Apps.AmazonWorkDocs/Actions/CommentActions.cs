using Amazon.WorkDocs;
using Apps.AmazonWorkDocs.Invocables;
using Apps.AmazonWorkDocs.Models.Entities;
using Apps.AmazonWorkDocs.Models.Request.Comment;
using Apps.AmazonWorkDocs.Models.Request.Document;
using Apps.AmazonWorkDocs.Models.Response.Comment;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonWorkDocs.Actions;

[ActionList]
public class CommentActions : AmazonWorkDocsInvocable
{
    public CommentActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List comments", Description = "List comments for a specific document version")]
    public async Task<ListCommentsResponse> ListComments([ActionParameter] DocumentVersionRequest request)
    {
        await using var commentEnumerator = Client.Paginators.DescribeComments(new()
        {
            DocumentId = request.DocumentId,
            VersionId = request.VersionId,
        }).Comments.GetAsyncEnumerator();

        var result = new List<CommentEntity>();
        while (await commentEnumerator.MoveNextAsync())
            result.Add(new(commentEnumerator.Current));

        return new(result);
    }

    [Action("Add comment", Description = "Add a new comment to the document")]
    public async Task<CommentEntity> AddComment([ActionParameter] AddCommentRequest request)
    {
        var response = await Client.CreateCommentAsync(new()
        {
            DocumentId = request.DocumentId,
            VersionId = request.VersionId,
            Text = request.Comment,
            NotifyCollaborators = request.NotifyCollaborators ?? default,
            Visibility = request.IsCommentPrivate is true ? CommentVisibilityType.PRIVATE : CommentVisibilityType.PUBLIC
        });

        return new(response.Comment);
    }

    [Action("Delete comment", Description = "Delete specific comment")]
    public Task DeleteComment([ActionParameter] CommentRequest request)
    {
        return Client.DeleteCommentAsync(new()
        {
            DocumentId = request.DocumentId,
            VersionId = request.VersionId,
            CommentId = request.CommentId
        });
    }
}