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
        public Section() { }
        public Section(int id, string name, string decr, string owner)
        {
            SectionId = id;
            NameSection = name;
            DecriptionSection = decr;
            OwnerSection = owner;
        }

        public int SectionId { get; set; }
        public string NameSection { get; set; }
        public string DecriptionSection { get; set; }
        public string OwnerSection { get; set; }
        public virtual List<Page> PagesOfSection { get; set; }
    }
}
