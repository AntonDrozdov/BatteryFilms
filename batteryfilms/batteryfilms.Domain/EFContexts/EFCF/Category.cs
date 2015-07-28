using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batteryfilms.Domain.EFContexts.EFCF
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Clip> Clips { get; set; }

        public Category()
        {
            Clips = new List<Clip>();
        }

    }
}
