using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EADS.Domain.Models.Entities;
using EADS.RazorDemo.Data;
using EADS.RazorDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EADS.RazorDemo.Pages.Demo
{
    public class DeleteModel : PageModel
    {
        private readonly EADSRazorDemoContext _context;
        private readonly IAPIService service;

        public DeleteModel(EADSRazorDemoContext context, IAPIService service)
        {
            _context = context;
            this.service = service;
        }

        //[BindProperty]
        public DemoPresentationObjectDatabaseReference DemoPresentationObject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var obj = _context.DemoObjects.Where(x => x.Id == id).FirstOrDefault();

            DemoPresentationObject = obj;
            
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var obj = _context.DemoObjects.Where(x => x.Id == id).FirstOrDefault();
            var response = await service.Delete(obj.DataStoreKey);
            if (response)
            {
                _context.DemoObjects.Remove(obj);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
