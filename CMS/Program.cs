using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Inf;
using CMS.Model;
using MySql.Data.MySqlClient;

namespace CMS
{
    class Program
    {
        static void Main(string[] args)
        {

            using (UserContext context = new UserContext())
            {

                Section sec2 = new Section(100, "1", "2", "3");

                context.Section.Add(sec2);
                context.SaveChanges();
                var section = context.Section;
                Console.WriteLine("Список объектов:");
                foreach (Section u in section)
                {
                    Console.WriteLine("{0}.{1} - {1}", u.NameSection, u.OwnerSection);
                }
            }
            //using (UserContext db = new UserContext())
            //{
            //    db.Database.CreateIfNotExists();

            //    Comment user1 = new Comment { ContentComment = "Hellow world" };
            //    Comment user2 = new Comment { OwnerComment = "Sam" };

            //    // добавляем их в бд
            //    db.Comment.Add(user1);
            //    db.Comment.Add(user2);
            //    db.SaveChanges();
            //    Console.WriteLine("Объекты успешно сохранены");

            //    // получаем объекты из бд и выводим на консоль
            //    var comment = db.Comment;
            //    Console.WriteLine("Список объектов:");
            //    foreach (Comment u in comment)
            //    {
            //        Console.WriteLine("{0}.{1} - {1}", u.OwnerComment, u.ContentComment);
            //    }
            //    IEnumerable<Page> pages = new PageRepository().GetAll();
            //    foreach (Page p in pages)
            //        Console.WriteLine(p.NamePage);
            //    Console.Read();
            //}

        }
    }
}

