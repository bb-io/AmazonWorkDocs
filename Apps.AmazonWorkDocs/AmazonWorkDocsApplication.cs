using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.AmazonWorkDocs;

public class AmazonWorkDocsApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.FileManagementAndStorage];
        set { }
    }
    
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