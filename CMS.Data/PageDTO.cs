using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data
{
    public class PageDto
    {
        public int PageId { get; set; }
        public string NamePage { get; set; }
        public string ContentPage { get; set; }
        public DateTime DateCreatePage { get; set; }
        public DateTime DateChangePage { get; set; }
        public string OwnerPage { get; set; }
        public string ChangerPage { get; set; }
        public  int SectionId { get; set; }

    }
}
