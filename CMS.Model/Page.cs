using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class Page
    {
        public Page() {
            PagesThis = new List<Page>();
            Comments = new List<Comment>();
            Marks = new List<Mark>();
        }
        public Page(int pageid, string name, string content, DateTime datecreate, DateTime datechange, string owner, string changer,int sectionid, Section section)
        {
            PageId = pageid;
            NamePage = name;
            ContentPage = content;
            DateCreatePage = datecreate;
            DateChangePage = datechange;
            OwnerPage = owner;
            ChangerPage = changer;
            SectionId = sectionid;
            Section = section;
        }
        public int PageId { get; set; }
        public string NamePage { get; set; }
        public string ContentPage { get; set; }
        public DateTime DateCreatePage { get; set; }
        public DateTime DateChangePage { get; set; }
        public string OwnerPage { get; set; }
        public string ChangerPage { get; set; }
        public int? SectionId { get; set; }
        public Section Section { get; set; }
        
        public virtual ICollection<Page> PagesThis { get; set; }
        public virtual ICollection<Comment> Comments { get; set;}
        public virtual ICollection<Mark> Marks { get; set; }

    }
}
