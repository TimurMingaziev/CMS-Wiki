using System.Linq;
using CMS.Model;
using CMS.Model.Domain;

namespace CMS.Inf.Repository
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
