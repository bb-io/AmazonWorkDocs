using Apps.AmazonWorkDocs.Api;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.AmazonWorkDocs.Invocables;

public class AmazonWorkDocsInvocable : BaseInvocable
{
    protected AmazonWorkDocsApiClient Client { get; }

    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    public AmazonWorkDocsInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new(Creds);
    }
}