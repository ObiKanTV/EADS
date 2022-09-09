namespace EADS.RazorDemo.Models.ViewModels;

public class DemoPresentationObjectVM
{
    public DemoPresentationObjectVM(string? name, string? description, string? phoneNumber, string? sSN)
    {
        Name = name;
        Description = description;
        PhoneNumber = phoneNumber;
        SSN = sSN;
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? SSN { get; set; }
}

