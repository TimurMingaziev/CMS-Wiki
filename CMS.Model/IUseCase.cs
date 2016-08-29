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

        void CreateSection(object dto);

        object CreatePage(object dto);
        
       void UpdatePage(object dto);
        void CreateComment(object dto);
        void CreateMark(object dto);

    }
}
