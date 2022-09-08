using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EADS.RazorDemo.Pages.Demo
{
    public class DetailsModel : PageModel
    {
        private readonly EADSRazorDemoContext _context;

        public DetailsModel(EADSRazorDemoContext context)
        {
            _context = context;
        }

        public DemoPresentationObjectDTO DemoPresentationObject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            //Check if it exists

            //GET request from API, await response

            //Pass into model and return page
            return Page();
        }
    }
}
