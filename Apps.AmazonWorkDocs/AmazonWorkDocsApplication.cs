using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonWorkDocs;

public class AmazonWorkDocsApplication : IApplication
{
    public string Name
    {
        get => "AmazonWorkDocs";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}