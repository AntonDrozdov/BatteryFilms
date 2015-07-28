using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using batteryfilms.Domain.EFContexts.EFCF;

namespace batteryfilms.MVC.Models
{
    public class EditClipModel
    {
        public Clip clip { get; set; }
        public IEnumerable<SelectListItem> AllCategories { get; set; }
        public IEnumerable<SelectListItem> VideoCategories { get; set; }
        public IEnumerable<SelectListItem> FotoCategories { get; set; }

        public EditClipModel()
        {
            AllCategories = new List<SelectListItem>();
            VideoCategories = new List<SelectListItem>();
            FotoCategories = new List<SelectListItem>();
        }
    }
}