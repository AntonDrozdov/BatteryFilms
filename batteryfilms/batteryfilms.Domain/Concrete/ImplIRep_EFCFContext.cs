using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using batteryfilms.Domain.Abstract;
using batteryfilms.Domain.EFContexts.EFCF;

namespace batteryfilms.Domain.Concrete
{
    public class ImplIRep_EFCFContext : IRepository
    {
        private EFCFContext contex; 
        public ImplIRep_EFCFContext()
        {
            contex = new  EFCFContext();
        }



        public IQueryable<Category> Categories
        {
            get { return contex.Category; }
        }

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
                    dbEntry.Description = clip.Description;
                    dbEntry.Categories = dbEntry.Categories.Union(clip.Categories).ToList();
                    dbEntry.ImageData = clip.ImageData;
                    dbEntry.ImageMimeType = clip.ImageMimeType;
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
        }




    }
}
