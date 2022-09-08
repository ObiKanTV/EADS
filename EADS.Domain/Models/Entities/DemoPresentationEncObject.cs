using System.ComponentModel.DataAnnotations;

namespace EADS.Domain.Models.Entities;

public class DemoPresentationEncObject : EntityBase
{
    public DemoPresentationEncObject(string? name, string? description, string? phoneNumber, string? fileContent, string? sSN, EncryptionValue encryptionValue)
    {
        Name = name;
        Description = description;
        PhoneNumber = phoneNumber;
        FileContent = fileContent;
        SSN = sSN;
        EncryptionValue = encryptionValue;
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FileContent { get; set; }
    public string? SSN { get; set; }
    [Required]
    public EncryptionValue EncryptionValue { get; set; }
}

