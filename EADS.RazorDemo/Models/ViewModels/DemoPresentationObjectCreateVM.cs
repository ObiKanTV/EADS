using System.ComponentModel.DataAnnotations;

namespace EADS.RazorDemo.Models.ViewModels
{
    public class DemoPresentationObjectCreateVM
    {
        public DemoPresentationObjectCreateVM(string? name, string? description, string? phoneNumber, FormFile? fileContent, string? sSN, string? passPhrase)
        {
            Name = name;
            Description = description;
            PhoneNumber = phoneNumber;
            FileContent = fileContent;
            SSN = sSN;
            PassPhrase = passPhrase;
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public FormFile? FileContent { get; set; }
        public string? SSN { get; set; }
        [Required]
        public string? PassPhrase { get; set; }
    }
}
