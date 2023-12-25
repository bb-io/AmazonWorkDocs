using Amazon.WorkDocs.Model;
using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonWorkDocs.Models.Entities;

public class DocumentVersionEntity
{
    [Display("Content created date")]
    public DateTime? ContentCreatedTimestamp { get; set; }

    [Display("Content modified date")]
    public DateTime? ContentModifiedTimestamp { get; set; }

    [Display("Content type")]
    public string ContentType { get; set; }

    [Display("Created date")]
    public DateTime? CreatedTimestamp { get; set; }

    [Display("Creator ID")]
    public string CreatorId { get; set; }

    [Display("ID")]
    public string Id { get; set; }

    [Display("Modified date")]
    public DateTime? ModifiedTimestamp { get; set; }

    [Display("Name")]
    public string Name { get; set; }

    [Display("Signature")]
    public string Signature { get; set; }

    [Display("Size")]
    public long? Size { get; set; }

    [Display("Status")]
    public string Status { get; set; }

    public DocumentVersionEntity(DocumentVersionMetadata original)
    {
        ContentCreatedTimestamp = original.ContentCreatedTimestamp;
        ContentModifiedTimestamp = original.ContentModifiedTimestamp;
        ContentType = original.ContentType;
        CreatedTimestamp = original.CreatedTimestamp;
        CreatorId = original.CreatorId;
        Id = original.Id;
        ModifiedTimestamp = original.ModifiedTimestamp;
        Name = original.Name;
        Signature = original.Signature;
        Size = original.Size;
        Status = original.Status;
    }
}