using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CMS.App;
using CMS.Inf;
using CMS.Model;
using MySql.Data.MySqlClient;
using NLog;

//using CMS.Model.Migrations;


namespace CMS
{
    class Program
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserContext, Configuration>());
            logger.Log(LogLevel.Info, "Application started");

      
            //var use = new Use();
            //use.CreatePage("hi", "myFriend", DateTime.Now, DateTime.Now, "me", "you",
            //    new SectionRepository().GetSectionById(1));

            //Console.WriteLine("PageRepository().GetAll()");
            //IEnumerable<Page> pages = new PageRepository().GetAll();
            //foreach (Page p in pages)
            //    Console.WriteLine(p.NamePage);

            //logger.Log(LogLevel.Info, "Repository Page get by id: {0}",
            //    new PageRepository().GetPageById(1).DateChangePage);

            new CallMthodFromJson().CallMethod("2");
            Console.WriteLine("успех");
            Console.ReadLine();
        }
    }
}

