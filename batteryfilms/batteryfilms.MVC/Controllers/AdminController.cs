using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using batteryfilms.Domain.Abstract;
using batteryfilms.Domain.EFContexts.EFCF;
using batteryfilms.MVC.Models;
using batteryfilms.MVC.HtmlHelpers;

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
            foreach (var cat in repository.Categories.Distinct().ToList())
            {
                 clipToEdit.AllCategories.Add( new SelectListItem { Text = cat.Title, Selected = false, Value = cat.Id.ToString() });
            }
                //mark each category as checked if clip is belong to the category
            clipToEdit.AllCategories.ToList().ForEach(
                item => item.Selected = clipToEdit.clip.Categories.ToList().Exists(clipcat => clipcat.Id.ToString() == item.Value)                
            );

            return View(clipToEdit);
        }
        [HttpPost]
        public ActionResult EditClip(EditClipModel clipToEdit, HttpPostedFileBase image)
        {
            //get commondata
            clipToEdit.clip.Id = Convert.ToInt32(ModelState["clip.Id"].Value.AttemptedValue);
            clipToEdit.clip.Title = ModelState["clip.Title"].Value.AttemptedValue;
            clipToEdit.clip.Description = ModelState["clip.Description"].Value.AttemptedValue;
            clipToEdit.clip.Url = ModelState["clip.Url"].Value.AttemptedValue;
            
            //get categories
            clipToEdit.clip.Categories.Clear();
            string[] selectedcats = ModelState["AllCategories"].Value.AttemptedValue.Split(new char[] { ',' });
            List<Category> AllCategories = repository.Categories.Distinct().ToList();
            for (int i=0; i<AllCategories.Count(); i++)
            {
                if (selectedcats[i]=="true") clipToEdit.clip.Categories.Add(AllCategories[i]); 
            }
            

            if (image != null)
            {
                clipToEdit.clip.ImageMimeType = image.ContentType;
                clipToEdit.clip.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(clipToEdit.clip.ImageData, 0, image.ContentLength);
            }

            repository.SaveClip(clipToEdit.clip);
            TempData["message"] = string.Format("{0} has been saved", clipToEdit.clip.Title);
            return RedirectToAction("ClipEditor");
        }
        public ViewResult CreateClip()
        {
            return View("EditClip", new EditClipModel());
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
