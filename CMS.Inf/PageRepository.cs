using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Data;
using CMS.Model;

namespace CMS.Inf
{

    public class PageRepository  : Repository<Page>
    {
        public Page GetPageById(int id)
        {
            using (var context = new UserContext())
            {
               return context.Set<Page>().FirstOrDefault(x => x.PageId == id);
            }
        }

        public void SavePage(Page page)
        {
            using (var context = new UserContext())
            {
                try
                {
                    context.Page.Add(page);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("IOException source: {0}", e.Source);
                    throw;
                }
            }

        }

    }
}
