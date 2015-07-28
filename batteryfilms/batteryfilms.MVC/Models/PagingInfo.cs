using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace batteryfilms.MVC.Models
{
    public class PagingInfo
    {
        public int TotalClips{get;set;}
        public int ClipsForPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get { return (int)Math.Ceiling((decimal)TotalClips / ClipsForPage); } }
    }
}