using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using batteryfilms.MVC.Models;

namespace batteryfilms.MVC.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(  this HtmlHelper html, 
                                                PagingInfo pageinfo, 
                                                Func<int, string> pageurl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pageinfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageurl(i));
                tag.InnerHtml = i.ToString();
                if (i == pageinfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                result.Append(tag.ToString());
            }
            string a = result.ToString();
            return MvcHtmlString.Create(result.ToString());
        }


    }
}