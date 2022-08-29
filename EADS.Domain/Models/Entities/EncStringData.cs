using System.ComponentModel.DataAnnotations;

namespace EADS.Domain.Models.Entities;

public class EncStringData : EntityBase
{
    public string Data { get; set; } = string.Empty;
    public string EncryptionValueId { get; set; } = string.Empty;
    [Required]
    public EncryptionValue EncryptionValue { get; set; }
}

