using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CMS.Model
{
    class Section
    {
        private string nameSection { get; set; }
        private string decriptionSection { get; set; }
        private string ownerSection { get; set; }
        private List<Page> pagesOfSection { get; set; }

    }
}
