using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace batteryfilms.Domain.EFContexts.EFCF
{
    public class Clip
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Clip Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter URL")]
        public string Url { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public Clip()
        {
            Categories = new List<Category>();
        }
    }
}
