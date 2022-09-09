using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EADS.Domain.Models.Entities;
using EADS.RazorDemo.Data;
using EADS.RazorDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EADS.RazorDemo.Pages.Demo
{
    public class IndexModel : PageModel
    {
        private readonly EADSRazorDemoContext _context;

        public IndexModel(EADSRazorDemoContext context)
        {
            _context = context;
        }

        public IList<DemoPresentationObjectReferenceVM> DemoPresentationObject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DemoObjects != null)
            {
                var demoPresentationObjectDatabaseReferences = new List<DemoPresentationObjectDatabaseReference>();
                demoPresentationObjectDatabaseReferences = await _context.DemoObjects.ToListAsync();
                DemoPresentationObject = new List<DemoPresentationObjectReferenceVM>();
                if (demoPresentationObjectDatabaseReferences == null) throw new NullReferenceException(nameof(demoPresentationObjectDatabaseReferences));
                foreach (var item in demoPresentationObjectDatabaseReferences)
                {
                    var listObject = new DemoPresentationObjectReferenceVM() 
                    { 
                        Id = item.Id,
                        DataStoreKey = item.DataStoreKey,
                        PassPhrase = item.PassPhrase
                    };
                    DemoPresentationObject.Add(listObject);
                }
            }
        }
    }
}

