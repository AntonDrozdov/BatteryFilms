using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using batteryfilms.Domain.EFContexts;

using batteryfilms.Domain.EFContexts.EFCF;

namespace batteryfilms.MVC.Models
{
    public class ClipsListViewModel
    {
        public IEnumerable<Clip> Clips { get; set; }
        public PagingInfo paginginfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}