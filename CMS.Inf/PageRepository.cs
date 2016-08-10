using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Data;
using CMS.Model;

namespace CMS.Inf
{
    public class PageRepository  : Repository<Page>
    {
      

        public Page FindByName(string name)
        {
            using (var db = new UserContext())
            {
                return db.Set<Page>().FirstOrDefault(u => u.NamePage == name);
            }
        }
    }
}
