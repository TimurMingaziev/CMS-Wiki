using System;
using System.Linq;
using AutoMapper;
using CMS.Data;
using CMS.Model.Domain;
using System.Data.Entity;
using NLog;

namespace CMS.Inf.Repository
{

    public class PageRepository  : Repository<PageDto>
    {
        UserContext _userContext;
        IConfigurationProvider _config;
        ILogger _logger;
        public PageRepository(ILogger logger)
        {
            _logger = logger;
            _userContext = new UserContext();
            _config = new MapperConfiguration(cfg => cfg.CreateMap<Page, PageDto>());
        }
        public Page GetPageById(int id)
        {
            using (var context = new UserContext())
            {
               return context.Set<Page>().FirstOrDefault(x => x.PageId == id);
            }
        }

        public void CreatePage(Page page)
        {
            try
            {
                var dest = _config.CreateMapper().Map<Page, PageDto>(page);
                _userContext.Page.Add(dest);
                _userContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }


        }
        public void UpdatePage(Page page)
        {
            var dest = _config.CreateMapper().Map<Page, PageDto>(page);
            _userContext.Entry(dest).State = EntityState.Unchanged;
            _userContext.SaveChanges();
        }

    }
}
