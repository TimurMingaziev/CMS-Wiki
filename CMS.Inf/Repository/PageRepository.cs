using System;
using System.Linq;
using AutoMapper;
using CMS.Data;
using CMS.Model;
using CMS.Model.Domain;

namespace CMS.Inf.Repository
{

    public class PageRepository  : Repository<Page>
    {
        UserContext _userContext;
        public PageRepository()
        {
            _userContext = new UserContext();
        }
        public Page GetPageById(int id)
        {
            using (var context = new UserContext())
            {
               return context.Set<Page>().FirstOrDefault(x => x.PageId == id);
            }
        }

        public void SavePage(Page page)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Page, PageDto>());
                IMapper mapper = config.CreateMapper();
                var dest = mapper.Map<Page, PageDto>(page);
                _userContext.Page.Add(dest);
                _userContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }


        }

    }
}
