using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CMS.Model
{
    public class Section
    {
        public int SectionId { get; set; }
        public string NameSection { get; set; }
        public string DecriptionSection { get; set; }
        public string OwnerSection { get; set; }
        public virtual List<Page> PagesOfSection { get; set; }
    }
}
