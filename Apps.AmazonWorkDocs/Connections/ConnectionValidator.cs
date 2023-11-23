using Amazon.Runtime.Internal;
using Amazon.WorkDocs.Model;
using Apps.AmazonWorkDocs.Api;
using Apps.AmazonWorkDocs.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;

namespace Apps.AmazonWorkDocs.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        var creds = authenticationCredentialsProviders.ToArray();
        using var client = new AmazonWorkDocsApiClient(creds);
        try
        {
            await client.GetDocumentAsync(new()
            {
                DocumentId = "documentId",
            }, cancellationToken);
        }
        catch (Exception ex)
        {
            if(ex is UnauthorizedResourceAccessException)
                return new()
                {
                    IsValid = true,
                };
        }

        return new()
        {
            IsValid = false
        };
    }
}