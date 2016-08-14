using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CMS.Inf;
using CMS.Model;
using MySql.Data.MySqlClient;
//using CMS.Model.Migrations;


namespace CMS
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserContext, Configuration>());

            using (UserContext context = new UserContext())
            {

               // Section user1 = new Section() { NameSection = "login1", DecriptionSection = "pass1234", OwnerSection = "1" };
               // Section user2 = new Section () { NameSection = "login2", DecriptionSection = "5678word2", OwnerSection = "2" };
               //// context.Section.AddRange(new List<Section> { user1, user2 });
               // context.Section.Add(user1);
               // context.Section.Add(user2);

               // context.SaveChanges();

               // Page page = new Page() { NamePage = "Main", ContentPage = "Hello world", OwnerPage = "1", ChangerPage = "2", DateChangePage = DateTime.Now, DateCreatePage = DateTime.Now, Section = user1 };
               // context.Page.Add(page);
               // context.SaveChanges();

               // Comment comment = new Comment() { ContentComment = "lol", OwnerComment = "1", Page = page };
               // context.Comment.Add(comment);
               // context.SaveChanges();

               // Mark mark = new Mark (){ MarkThis = 1, OwnerMark = "1", DateMark = DateTime.Now, Page = page };
               // context.Mark.Add(mark);
               // context.SaveChanges();

                foreach (Page pl in context.Page.Include("Section"))
                    Console.WriteLine("{0}, {1}", pl.NamePage, pl.Section.NameSection);

                foreach (Comment c in context.Comment.Include("Page"))
                    Console.WriteLine("{0}, {1}", c.ContentComment, c.OwnerComment,c.Page.NamePage);

            }
            Console.WriteLine("успех");
            Console.ReadLine();
        }
    }
}

