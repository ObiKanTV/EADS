using EADS.Domain.Models.Entities.Shared;

namespace EADS.Domain.Models.DTOs
{
    public class DemoPresentationObjectDTO : DTOBase
    {
        public DemoPresentationObjectDTO(string? name, string? description, string? phoneNumber, string? fileContent, string? sSN)
        {
            Name = name;
            Description = description;
            PhoneNumber = phoneNumber;
            FileContent = fileContent;
            SSN = sSN;
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FileContent { get; set; }
        public string? SSN { get; set; }
    }
}
