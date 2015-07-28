using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using batteryfilms.Domain.Abstract;

using batteryfilms.Domain.EFContexts.EFCF;

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
            //return View();
            return View(repository.Clips.OrderBy(clip=>clip.Title));
        }
        public ViewResult EditClip(int Id)
        {
            Clip clip = repository.Clips.FirstOrDefault(clipitem => clipitem.Id == Id);
            return View(clip);
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
