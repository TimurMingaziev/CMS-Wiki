using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string ContentComment { get; set; }
        public string OwnerComment { get; set; }

        public virtual Page Page { get; set; }

    }
}
