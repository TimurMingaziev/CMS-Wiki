using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CMS.Model
{
   
    public class UserContext:DbContext
    {
        //public UserContext()
        //    :base("UserContext")
        //{ Database.SetInitializer<UserContext>(null); }
        public DbSet<Section> Section { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Mark> Mark { get; set; }
        public DbSet<Comment> Comment { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
