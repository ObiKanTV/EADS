using System.ComponentModel.DataAnnotations;

namespace EADS.RazorDemo.Models.ViewModels
{
    public class DemoPresentationObjectCreateVM
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SSN { get; set; }
    }
}
