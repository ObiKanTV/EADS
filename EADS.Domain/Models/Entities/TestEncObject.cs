using System.ComponentModel.DataAnnotations;

namespace EADS.Domain.Models.Entities;

public class TestEncObject : EntityBase
{
    public string Message { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerNumber { get; set; } = string.Empty;
    public string CustomerPassword { get; set; } = string.Empty;
    public string CustomerPhoneNumber { get; set; } = string.Empty;
    public string EncryptionValueId { get; set; } = string.Empty;
    [Required]
    public EncryptionValue EncryptionValue { get; set; }
}

