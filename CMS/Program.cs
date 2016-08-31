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
using RabbitMQ.Client;
using CMS.Inf.Migrations;


namespace CMS
{
    class Program
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserContext, Configuration>());
            logger.Log(LogLevel.Info, "Application started");
            InitializeClass init = new InitializeClass(logger);
            init.StartInit();
            Console.WriteLine("успех");
            Console.ReadKey();
        }
    }
}

