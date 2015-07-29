using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using batteryfilms.Domain.Abstract;
using batteryfilms.Domain.EFContexts.EFCF;
using batteryfilms.MVC.Models;

namespace batteryfilms.MVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IRepository repository;

        public AdminController(IRepository _repository)
        {
            repository = _repository;
        }
        //редактирование списка клипов
        public ViewResult ClipEditor()
        {
            return View(repository.Clips.OrderBy(clip=>clip.Title));
        }
        public ViewResult EditClip(int Id)
        {
            EditClipModel clipToEdit = new EditClipModel();
            //get clip from db to edit
            clipToEdit.clip = repository.Clips.FirstOrDefault(clipitem => clipitem.Id == Id); ;

            //get all categories to choose
            //repository.Categories.Distinct().ToList().ForEach(cat => clipToEdit.AllCategories.ToList().Add(new SelectListItem { Text = cat.Title, Selected = false, Value = cat.Id.ToString() }));
            //clipToEdit.AllCategories = from cat in repository.Categories.Distinct().ToList() select new SelectListItem { Text = cat.Title, Selected = false, Value = cat.Id.ToString() };
            foreach (var cat in repository.Categories.Distinct().ToList())
            {
                 clipToEdit.AllCategories.Add( new SelectListItem { Text = cat.Title, Selected = false, Value = cat.Id.ToString() });
            }
            foreach (var clipcat in clipToEdit.clip.Categories) 
            {
                foreach (var cat in clipToEdit.AllCategories)
                {
                    if (cat.Value == clipcat.Id.ToString()) 
                    { 
                        cat.Selected = true; 
                    }       
                }
            }
            /*
            clipToEdit.AllCategories.ToList().ForEach(
                item => item.Selected = clipToEdit.clip.Categories.ToList().Exists(clipcat => clipcat.Id.ToString() == item.Value)                
            );*/

            return View(clipToEdit);
        }
        [HttpPost]
        public ActionResult EditClip(Clip clip, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                
                if (image != null)
                {
                    clip.ImageMimeType = image.ContentType;
                    clip.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(clip.ImageData, 0, image.ContentLength);
                }
                
                repository.SaveClip(clip);
                TempData["message"] = string.Format("{0} has been saved", clip.Title);
                return RedirectToAction("ClipEditor");
            }
            else
            {
                return View(clip);
            }
        }
        public ViewResult CreateClip()
        {
            return View("EditClip", new Clip());
        }
        [HttpPost]
        public ActionResult DeleteClip(int clipId)
        {
            Clip deletedClip = repository.DeleteClip(clipId);
            if (deletedClip!=null)
            {
                TempData["message"] = string.Format("{0} has been deleted", deletedClip.Title);
                return RedirectToAction("ClipEditor");
            }

            return RedirectToAction("ClipEditor");
        }
        
        /*
        //редактированеи списка фото
        public ViewResult FotoEditor()
        {
            //return View(repository.Fotoes.OrderBy(foto=>foto.Category));
            return View();
        }
        public ViewResult EditFoto(int Id)
        {
            //Foto foto = repository.Fotoes.FirstOrDefault(fotoitem => fotoitem.Id == Id);
            //return View(foto);
            return View();
        }
        [HttpPost]
        public ActionResult EditFoto(Foto foto, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                /*
                if (image != null)
                {
                    foto.ImageMimeType = image.ContentType;
                    foto.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(foto.ImageData, 0, image.ContentLength);
                }
                
                repository.SaveFoto(foto);
                TempData["message"] = string.Format("{0} has been saved", foto.Title);
                return RedirectToAction("FotoEditor");
                return View();
            }
            else
            {
                return View(foto);
            }
        }
        public ViewResult CreateFoto()
        {
            return View("EditFoto", new Foto());
        }
        [HttpPost]
        public ActionResult DeleteFoto(int fotoId)
        {
            /*
            Foto deletedFoto = repository.DeleteFoto(fotoId);
            if (deletedFoto != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", deletedFoto.Title);
                return RedirectToAction("FotoEditor");
            }
            return RedirectToAction("FotoEditor");
            return View();
        }*/


        //редактирование списка промо акций
        public ViewResult PromoEditor()
        {
            return View();
        }
        //редактирование списка статей
        public ViewResult ArticleEditor()
        {
            return View();
        }

        public FileContentResult GetImage(int Id)
        {
            Clip clip = repository.Clips.FirstOrDefault(p => p.Id== Id);
            if (clip != null)
            {
                return File(clip.ImageData, clip.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
