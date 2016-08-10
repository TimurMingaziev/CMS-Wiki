using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    interface IUse
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
        void CreateSection(string name,string owner);

    }
}
