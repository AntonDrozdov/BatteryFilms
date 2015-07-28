using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using batteryfilms.Domain.EFContexts;
using batteryfilms.Domain.Abstract;

namespace batteryfilms.Domain.Concrete
{
    class EFRepositoryDbF//: IRepository
    {
        /*
        EFDbFContext contex = new EFDbFContext();

        public IQueryable<Clip> Clips 
        {
            get { return contex.Clip; }
        }
        public void SaveClip(Clip clip)
        {

            if (clip.Id == 0)
            {
                contex.Clip.Add(clip);
            }
            else
            {
                Clip dbEntry = contex.Clip.Find(clip.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = clip.Title;
                    dbEntry.Category = clip.Category;
                    
                    //dbEntry.Description = clip.Description;
                    //dbEntry.url = clip.url;
                    //dbEntry.ImageData = clip.ImageData;
                    //dbEntry.ImageMimeType = clip.ImageMimeType;
                    
                }
            }
            contex.SaveChanges();
        }
        public Clip DeleteClip(int clipId)
        {
            Clip dbEntry = contex.Clip.Find(clipId);
            if (dbEntry != null)
            {
                contex.Clip.Remove(dbEntry);
                contex.SaveChanges();
            }
            return dbEntry;
        }*/
            /*
        public IQueryable<Foto> Fotoes 
        {
            get { return contex.Fotoes; } 
        }
        public void SaveFoto(Foto foto)
        {
            if (foto.Id == 0)
            {
                contex.Fotoes.Add(foto);
            }
            else 
            {
                Foto dbEntry = contex.Fotoes.Find(foto.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = foto.Title;
                    dbEntry.Category = foto.Category;
                    //dbEntry.Description = foto.Description;
                    //dbEntry.ImageData = foto.ImageData;
                    //dbEntry.ImageMimeType = foto.ImageMimeType;
                }
            }

            contex.SaveChanges();
        }
        public Foto DeleteFoto(int fotoId)
        {
            Foto dbEntry = contex.Fotoes.Find(fotoId);
            if (dbEntry != null)
            {
                contex.Fotoes.Remove(dbEntry);
                contex.SaveChanges();
            }
            return dbEntry;
        }

        public IQueryable<Category> Categories 
        {
            get { return contex.Categories; } 
        }*/
    }
}
