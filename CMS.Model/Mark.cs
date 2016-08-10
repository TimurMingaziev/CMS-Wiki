using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class Mark
    {
        public int MarkId { get; set; }
        public short MarkThis { get; set; }
        public string OwnerMark { get; set; }
        public DateTime DateMark { get; set; }

        public virtual Page Page { get; set; }
    }
}
