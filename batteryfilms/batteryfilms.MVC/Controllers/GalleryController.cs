using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using batteryfilms.Domain.Abstract;
using batteryfilms.MVC.Models;
using batteryfilms.Domain.EFContexts.EFCF;

namespace batteryfilms.MVC.Controllers
{
    public class GalleryController : Controller
    {
        private IRepository repository;
        private int ClipsForPage = 6;


        public GalleryController(IRepository cliprepository)
        {
            this.repository = cliprepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ClipsListViewModel dataForClipsList = new ClipsListViewModel
            {
                Clips = repository.Clips.Where(clip=>category=="ALL"||clip.Categories.FirstOrDefault(item=>item.Title==category)!=null)
                                        .OrderBy(clip=>clip.Id)
                                        .Skip((page-1)*ClipsForPage)
                                        .Take(ClipsForPage),
                paginginfo = new PagingInfo
                {
                    ClipsForPage = ClipsForPage,
                    CurrentPage = page,
                    TotalClips = category == "ALL" ? repository.Clips.Count() : repository.Clips.Where(clip => clip.Categories.FirstOrDefault(item => item.Title == category) != null).Count()
                },
                CurrentCategory = category
            };

            return View(dataForClipsList);
        }

        /*
               public FileContentResult GetClipImage(int Id)
               {
           
                   Clip clip = repository.Clips.FirstOrDefault(clipitem => clipitem.Id == Id);
                   if (clip != null)
                   {
                       return File(clip.ImageData, clip.ImageMimeType);
                   }
                   else
                   {
                       return null;
                   }
            
               }

               public FileContentResult GetFoto(int Id)
               {
            
                   Foto foto = repository.Fotoes.FirstOrDefault(fotoitem => fotoitem.Id == Id);
                   if (foto != null)
                   {
                       return File(foto.ImageData, foto.ImageMimeType);
                   }
                   else
                   {
                       return null;
                   }
            
               }
               */
    }
}
