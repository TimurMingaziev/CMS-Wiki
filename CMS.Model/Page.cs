using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class Page
    {
        public Page() { }
        public Page(int pageId, string name, string content, DateTime datecreate, DateTime datechange, string owner, string changer, Section section)
        {
            PageId = pageId;
            NamePage = name;
            ContentPage = content;
            DateCreatePage = datecreate;
            DateChangePage = datechange;
            OwnerPage = owner;
            ChangerPage = changer;
            Section = section;
        }
        public int PageId { get; set; }
        public string NamePage { get; set; }
        public string ContentPage { get; set; }
        public DateTime? DateCreatePage { get; set; }
        public DateTime? DateChangePage { get; set; }
        public string OwnerPage { get; set; }
        public string ChangerPage { get; set; }
        public Section Section { get; set; }
        
        public virtual List<Page> pagesThis { get; set; }
        public virtual List<Comment> Comments { get; set;}
        public virtual List<Mark> Marks { get; set; }

    }
}
