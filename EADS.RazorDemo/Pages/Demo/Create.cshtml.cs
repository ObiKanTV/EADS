using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EADS.Domain.Models.DTOs;
using EADS.Domain.Models.Entities;
using EADS.RazorDemo.Models.ViewModels;
using EADS.RazorDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EADS.RazorDemo.Pages.Demo
{
    public class CreateModel : PageModel
    {
        private readonly EADSRazorDemoContext _context;
        private readonly IFormFileService formFileService;

        public CreateModel(EADSRazorDemoContext context, IFormFileService formFileService)
        {
            _context = context;
            this.formFileService = formFileService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DemoPresentationObjectCreateVM DemoPresentationObject { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            //Validate
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("You are dumb");
            }

            //Send to API and await response
            var demoObjectDTO = new DemoPresentationObjectDTO(DemoPresentationObject.Name,
                                                              DemoPresentationObject.Description, 
                                                              DemoPresentationObject.PhoneNumber,
                                                              await formFileService.ToByteArray(DemoPresentationObject.FileContent),
                                                              DemoPresentationObject.SSN);


            //Save Reference with the Id from response in DB
            var referenceObject = new DemoPresentationObjectDatabaseReference()
            {
                PassPhrase = DemoPresentationObject.PassPhrase,
                DataStoreKey = ""
            
            };
            _context.Add(referenceObject);

            return RedirectToPage("./Index");
        }
    }
}
