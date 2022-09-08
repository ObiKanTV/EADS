using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EADS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

    public class EADSRazorDemoContext : DbContext
    {
        public EADSRazorDemoContext (DbContextOptions<EADSRazorDemoContext> options)
            : base(options)
        {
        }
    public DbSet<DemoPresentationObjectDatabaseReference> DemoObjects { get; set; } = default!;
    }
