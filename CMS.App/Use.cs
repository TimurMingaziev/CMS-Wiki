using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Inf;
using  CMS.Model;

namespace CMS.App
{
    public class Use : IUse
    {
        public void CreateComment(string content, string owner)
        {
            throw new NotImplementedException();
        }

        public void CreateMark(short mark, string owner, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void CreatePage(string name, string content, DateTime dateCreate, DateTime dateChange, string owner, string changer, Section section)
        {
            var page = new Page()
            {
                NamePage = name,
                ChangerPage = changer,
                ContentPage = content,
                DateChangePage = dateChange,
                DateCreatePage = dateCreate,
                Section = section,
                OwnerPage = owner
            };
            new PageRepository().SavePage(page);
        }

        public void CreateSection(string name, string owner)
        {
            
        }

        public void CreateSection(string name, string descr, string owner)
        {
            throw new NotImplementedException();
        }

        public void UpdatePage(Page page)
        {
            
            throw new NotImplementedException();
        }
    }
}
