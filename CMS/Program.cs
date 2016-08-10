using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Model;

namespace CMS
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                Comment user1 = new Comment { ContentComment= "Hellow world"};
                Comment user2 = new Comment { OwnerComment = "Sam"};

                // добавляем их в бд
                db.Comment.Add(user1);
                db.Comment.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var comment = db.Comment;
                Console.WriteLine("Список объектов:");
                foreach (Comment u in comment)
                {
                    Console.WriteLine("{0} - {1}", u.OwnerComment, u.ContentComment);
                }
            }
            Console.Read();
        }
    }
}
