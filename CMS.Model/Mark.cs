using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class Mark
    {
        public Mark() { }
        public Mark(int markid, short mark, string owner, DateTime date)
        {
            MarkId = markid;
            MarkThis = mark;
            OwnerMark = owner;
            DateMark = date;
        }

        public int MarkId { get; set; }
        public short MarkThis { get; set; }
        public string OwnerMark { get; set; }
        public DateTime DateMark { get; set; }

        public virtual Page Page { get; set; }
    }
}
