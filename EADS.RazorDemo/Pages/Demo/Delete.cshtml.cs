using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EADS.RazorDemo.Pages.Demo
{
    public class DeleteModel : PageModel
    {
        private readonly EADSRazorDemoContext _context;

        public DeleteModel(EADSRazorDemoContext context)
        {
            _context = context;
        }

        //[BindProperty]
        //public DemoPresentationObjectDTO DemoPresentationObject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            //Check if it exists
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            //Delete from DemoDB

            //Delete from API

            //Await response

            //Return

            return RedirectToPage("./Index");
        }
    }
}
