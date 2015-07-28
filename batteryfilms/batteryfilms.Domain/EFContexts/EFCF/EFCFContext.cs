using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace batteryfilms.Domain.EFContexts.EFCF
{
    class EFCFContext : DbContext
    {
        public DbSet<Clip> Clip { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
