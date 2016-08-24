using System;

namespace CMS.Model.Domain
{
    public class Mark
    {
        public Mark() { }
        public Mark(int markid, short mark, string owner, DateTime date, Page page, int pageid)
        {
            MarkId = markid;
            MarkThis = mark;
            OwnerMark = owner;
            DateMark = date;
            Page = page;
            PageId = pageid;
        }

        public int MarkId { get; set; }
        public short MarkThis { get; set; }
        public string OwnerMark { get; set; }
        public DateTime DateMark { get; set; }

        public int? PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}
