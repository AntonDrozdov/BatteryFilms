using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using batteryfilms.MVC.Models;
using batteryfilms.Domain.EFContexts.EFCF;

namespace batteryfilms.MVC.HtmlHelpers
{
    public static class ChkbForCats
    {
        public static MvcHtmlString ClipCatsChkbs(  this HtmlHelper html,
                                                    List<Category> AllCats,
                                                    List<Category> clipCats)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<table>");
            for (int i = 1; i <= AllCats.Count(); i++)
            {
                TagBuilder tag = new TagBuilder("input");
                tag.MergeAttribute("name", "AllCategories");
                tag.MergeAttribute("type", "checkbox");
                tag.MergeAttribute("value", "true");
                if(clipCats.Contains(AllCats[i])) tag.MergeAttribute("checked", "checked");

                result.Append("<tr><td>" + tag.ToString() + "</td><td>" + "<label for=\"\">" + AllCats[i].Title +"</label></td></tr>");
            }
            result.Append("</table>");

            string a = result.ToString();
            return MvcHtmlString.Create(result.ToString());
        }

    }
}