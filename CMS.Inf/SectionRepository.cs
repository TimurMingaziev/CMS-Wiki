using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Model;

namespace CMS.Inf
{
    public class SectionRepository : Repository<Section>
    {
        public Section GetSectionById(int id)
        {
            using (var context = new UserContext())
            {
                return context.Set<Section>().FirstOrDefault(x => x.SectionId == id);
            }
        }
    }
}
