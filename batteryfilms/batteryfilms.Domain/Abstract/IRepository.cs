using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using batteryfilms.Domain.EFContexts.EFCF;


namespace batteryfilms.Domain.Abstract
{
    public interface IRepository
    {
        //вся работа с категориями ведется через форму редактирования клипов и фото, поэтому для них нет отдельный функций удаления и редактирования
        IQueryable<Category> Categories { get; }

        IQueryable<Clip> Clips { get; }
        void SaveClip(Clip clip);
        Clip  DeleteClip(int clipId);
    }
}
