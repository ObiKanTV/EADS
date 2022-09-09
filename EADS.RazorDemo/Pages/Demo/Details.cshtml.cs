using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using EADS.Domain.Models.DTOs;
using EADS.Domain.Models.Entities;
using EADS.RazorDemo.Data;
using EADS.RazorDemo.Models.ViewModels;
using EADS.RazorDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EADS.RazorDemo.Pages.Demo
{
    public class DetailsModel : PageModel
    {
        private readonly EADSRazorDemoContext _context;
        private readonly IAPIService service;
        private readonly IFormFileService formFileService;

        public DetailsModel(EADSRazorDemoContext context, IAPIService service, IFormFileService formFileService)
        {
            _context = context;
            this.service = service;
            this.formFileService = formFileService;
        }
        [BindProperty]
        public DemoPresentationObjectVM DemoPresentationObject { get; set; } = default!;
        public DemoPresentationObjectDTO DemoObject { get; set; }
        [BindProperty]
        public string Id { get; set; }


        public async Task<IActionResult> OnGetAsync(string id)
        {
            //Check if it exists
            if (!await _context.DemoObjects.AnyAsync(x => x.Id == id))
            {
                return NotFound();
            }
            Id = id;

            var obj = await _context.DemoObjects.Where(x => x.Id == id).FirstOrDefaultAsync();
            

            //GET request from API, await response
            var response = await service.Get(obj.DataStoreKey, obj.PassPhrase);
            DemoObject = response;
            DemoPresentationObject = new(response.Name, response.Description, response.PhoneNumber, response.SSN);

            
            //Pass into model and return page
            return Page();
        }
        public async Task<FileResult> OnGetDownload(string id)
        {
            var obj = await _context.DemoObjects.Where(x => x.Id == id).FirstOrDefaultAsync();
            var response = await service.Get(obj.DataStoreKey, obj.PassPhrase);

            return File(Convert.FromBase64String(response.FileContent), obj.FileType, obj.FileName);
        }
    }
}
