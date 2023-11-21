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
            var w = await client.DescribeUsersAsync(new()
            {
                OrganizationId = creds.Get(CredsNames.OrganizationId).Value
            }, cancellationToken);

            return new()
            {
                IsValid = true
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                IsValid = false,
                Message = ex.Message
            };
        }
    }
}