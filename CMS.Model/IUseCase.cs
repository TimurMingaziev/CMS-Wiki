using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Model.Domain;


namespace CMS.Model
{
    public interface IUseCase
    {
        //        1.
        //Созадние раздела
        //2.
        //Создание страницы
        //3.
        //Редактирование страницы
        //4.
        //Добавление коментария
        //5.
        //Выставление оценки

        void CreateSection(string name, string descr, string owner);

        object CreatePage(object dto);
        
       void UpdatePage(int pageid, string name, string content, DateTime datecreate, DateTime datechange, string owner, string changer, int sectionid);
        void CreateComment(string content, string owner);
        void CreateMark(short mark, string owner, DateTime date, int pageId);

    }
}
