using Amazon.WorkDocs.Model;
using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonWorkDocs.Models.Entities;

public class DocumentEntity
{
    [Display("Created date")]
    public DateTime? CreatedTimestamp { get; set; }

    [Display("Creator ID")]
    public string CreatorId { get; set; }

    [Display("Document ID")]
    public string Id { get; set; }

    [Display("Labels")]
    public IEnumerable<string> Labels { get; set; }

    [Display("Latest version")]
    public DocumentVersionEntity LatestVersionMetadata { get; set; }

    [Display("Modified date")]
    public DateTime? ModifiedTimestamp { get; set; }

    [Display("Parent folder ID")]
    public string ParentFolderId { get; set; }

    [Display("Resource state")]
    public string ResourceState { get; set; }
    
    public DocumentEntity(DocumentMetadata metadata)
    {
        CreatedTimestamp = metadata.CreatedTimestamp;
        CreatorId = metadata.CreatorId;
        Id = metadata.Id;
        Labels = metadata.Labels;
        LatestVersionMetadata = new(metadata.LatestVersionMetadata);
        ModifiedTimestamp = metadata.ModifiedTimestamp;
        ParentFolderId = metadata.ParentFolderId;
        ResourceState = metadata.ResourceState;
    }
}