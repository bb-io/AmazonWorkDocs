using Amazon.WorkDocs.Model;
using Blackbird.Applications.Sdk.Common;

namespace Apps.AmazonWorkDocs.Models.Entities;

public class UserEntity
{
    [Display("Created date")]
    public DateTime? CreatedTimestamp { get; set; }

    [Display("Email")]
    public string EmailAddress { get; set; }

    [Display("Given name")]
    public string GivenName { get; set; }

    [Display("User ID")]
    public string Id { get; set; }

    [Display("Locale")]
    public string Locale { get; set; }

    [Display("Modified date")]
    public DateTime? ModifiedTimestamp { get; set; }

    [Display("Organization ID")]
    public string OrganizationId { get; set; }

    [Display("Recycle bin folder ID")]
    public string RecycleBinFolderId { get; set; }

    [Display("Root folder ID")]
    public string RootFolderId { get; set; }

    [Display("Status")]
    public string Status { get; set; }

    [Display("Surname")]
    public string Surname { get; set; }

    [Display("Time zone ID")]
    public string TimeZoneId { get; set; }

    [Display("Type")]
    public string Type { get; set; }

    [Display("Username")]
    public string Username { get; set; }

    public UserEntity(User user)
    {
        CreatedTimestamp = user.CreatedTimestamp;
        EmailAddress = user.EmailAddress;
        GivenName = user.GivenName;
        Id = user.Id;
        Locale = user.Locale;
        ModifiedTimestamp = user.ModifiedTimestamp;
        OrganizationId = user.OrganizationId;
        RecycleBinFolderId = user.RecycleBinFolderId;
        RootFolderId = user.RootFolderId;
        Status = user.Status;
        Surname = user.Surname;
        TimeZoneId = user.TimeZoneId;
        Type = user.Type;
        Username = user.Username;
    }
}