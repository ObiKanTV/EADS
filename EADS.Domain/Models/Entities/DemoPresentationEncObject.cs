using System.ComponentModel.DataAnnotations;

namespace EADS.Domain.Models.Entities;

public class DemoPresentationEncObject : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FileContent { get; set; }
    public string? SSN { get; set; }
    public string? EncryptionValueId { get; set; }
    public EncryptionValue? EncryptionValue { get; set; }
}

