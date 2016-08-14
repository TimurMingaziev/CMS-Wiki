using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class Comment
    {
        public Comment() { }
        public Comment(int commentid,string content, string owner, Page page, int pageid)
        {
            CommentId = commentid;
            ContentComment = content;
            OwnerComment = owner;
            Page = page;
            PageId = pageid;

        }
        public int CommentId { get; set; }
        public string ContentComment { get; set; }
        public string OwnerComment { get; set; }

        public int? PageId { get; set; }
        public virtual Page Page { get; set; }

    }
}
