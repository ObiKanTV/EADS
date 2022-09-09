using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EADS.Domain.Models.DTOs;
using EADS.Domain.Models.Entities;
using EADS.RazorDemo.Data;
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
        private readonly IAPIService service;

        public CreateModel(EADSRazorDemoContext context, IFormFileService formFileService, IAPIService service)
        {
            _context = context;
            this.formFileService = formFileService;
            this.service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DemoPresentationObjectCreateVM DemoPresentationObject { get; set; } = default!;
        [BindProperty]
        public IFormFile formFile { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //Validate
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("You are dumb");
            }
            if (formFile == null)
            {
                throw new ArgumentException("You are dumber than dumb");
            }

            //Send to API and await response
            var passPhrase = service.GeneratePassPhraseAsync();
            var demoObjectDTO = new DemoPresentationObjectDTO(DemoPresentationObject.Name,
                                                              DemoPresentationObject.Description, 
                                                              DemoPresentationObject.PhoneNumber,
                                                              await formFileService.ToString(formFile as FormFile),
                                                              DemoPresentationObject.SSN);
            demoObjectDTO.PassPhrase = passPhrase;
            var response = await service.Post(demoObjectDTO);
            if (response == null)
            {
                throw new NullReferenceException("response was null");
            }



            //Save Reference with the Id from response in DB
            var referenceObject = new DemoPresentationObjectDatabaseReference()
            {
                PassPhrase = passPhrase,
                DataStoreKey = response,
                FileName = formFile.FileName,
                FileType = formFile.ContentType
            };
            _context.Add(referenceObject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
