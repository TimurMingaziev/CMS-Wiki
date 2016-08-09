using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    class Page
    {
        private string namePage { get; set; }
        private string contentPage { get; set; }
        private DateTime dateCreatePage { get; set; }
        private DateTime dateChangePage { get; set; }
        private string ownerPage { get; set; }
        private string changerPage { get; set; }

        List<Page> pagesThis { get; set; }
        List<Comment> comments { get; set;}
        List<Mark> marks { get; set; }

    }
}
