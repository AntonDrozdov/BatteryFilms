using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using batteryfilms.Domain.Abstract;
using batteryfilms.Domain.EFContexts;
using batteryfilms.Domain.EFContexts.EFCF;


namespace batteryfilms.MVC.Controllers
{
    public class VideoCategoriesController : Controller
    {
        private IRepository repository;

        public VideoCategoriesController(IRepository cliprepository)
        {
            repository = cliprepository;
        }
        public PartialViewResult  VideoCategories(string category = "ALL")
        {
            /*
            ViewBag.CurrentCategory = category;

            //List<int> CategoriesIds = 
            List<int> CategoriesIds = repository.ClipCategoryRel.Select(cat => cat.Category_Id).Distinct().ToList();
                    //ClipCategoryRel.Select(catid=>)


            IEnumerable<string> categories = repository.Categories
                                    .Where(cat => CategoriesIds.Exists(catId=>catId==cat.Id))
                                    .Select(cat => cat.Title)
                                    .Distinct()
                                    .OrderBy(cat => cat); 
            
            return PartialView(categories);*/
            return PartialView();
        }
    }
}
