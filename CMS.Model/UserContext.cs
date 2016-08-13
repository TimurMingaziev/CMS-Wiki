using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using System.Data.Common;

namespace CMS.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UserContext : DbContext
    {

        public UserContext()
            : base("UserContext")
        {
            
        }

        // Constructor to use on a DbConnection that is already opened
        public UserContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
        public DbSet<Section> Section { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Mark> Mark { get; set; }
        public DbSet<Comment> Comment { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Section>().MapToStoredProcedures();
            modelBuilder.Entity<Page>().MapToStoredProcedures();
            modelBuilder.Entity<Mark>().MapToStoredProcedures();
            modelBuilder.Entity<Comment>().MapToStoredProcedures();
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
