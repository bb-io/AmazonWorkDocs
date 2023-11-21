using Amazon;
using Amazon.Runtime;
using Amazon.WorkDocs;
using Apps.AmazonWorkDocs.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;

namespace Apps.AmazonWorkDocs.Api;

public class AmazonWorkDocsApiClient : AmazonWorkDocsClient
{
    public AmazonWorkDocsApiClient(AuthenticationCredentialsProvider[] creds) : base(GetAwsCreds(creds), new AmazonWorkDocsConfig()
    {
        RegionEndpoint = RegionEndpoint.USEast1,
    })
    {
    }

    private static AWSCredentials GetAwsCreds(AuthenticationCredentialsProvider[] creds)
    {
        var key = creds.Get(CredsNames.AccessKey).Value;
        var secret = creds.Get(CredsNames.AccessSecret).Value;

        return new BasicAWSCredentials(key, secret);
    }
}