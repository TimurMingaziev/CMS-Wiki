using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Inf;
using CMS.Inf.Repository;
using CMS.Model;
using CMS.Model.Domain;
using NLog;

namespace CMS.App
{
    public class Use : IUse
    {
        PageRepository _pageRepo;
        SectionRepository _sectionRepo;
        CommentRepository _commentRepo;
        MarkRepository _markRepo;
        ILogger _logger;

        public Use(ILogger logger)
        {
            _logger = logger;
            _pageRepo = new PageRepository(_logger);
            _sectionRepo = new SectionRepository(_logger);
            _commentRepo = new CommentRepository(_logger);
            _markRepo = new MarkRepository(_logger);
        }

        public void CreateComment(string content, string owner)
        {
            var comment = new Comment()
            {
                ContentComment = "lol",
                OwnerComment = "Tim",
                PageId = 1
            }; 
        }

        public void CreateMark(short markThis, string owner, DateTime date, int pageId)
        {
            var mark = new Mark()
            {
                MarkThis = markThis,
                OwnerMark = owner,
                DateMark = date,
                PageId = pageId
            };
            _markRepo.CreateMark(mark);

        }

        public void CreatePage(string name, string content, DateTime dateCreate, DateTime dateChange, string owner, string changer, Section section)
        {
            var page = new Page
            {
                NamePage = name,
                ChangerPage = changer,
                ContentPage = content,
                DateChangePage = dateChange,
                DateCreatePage = dateCreate,
                Section = section,
                OwnerPage = owner
            };
            _pageRepo.CreatePage(page);
        }
        

        public void CreateSection(string name, string descr, string owner)
        {
            var section = new Section
            {
                NameSection = name,
                DecriptionSection = descr,
                OwnerSection = owner
            };
            _sectionRepo.CreateSection(section);

        }

        public void UpdatePage(int pageid, string name, string content, DateTime datecreate, DateTime datechange, string owner, string changer, int sectionid)
        {
            var page = new Page();
            page.ChangePage( pageid,  name,  content,  datecreate,  datechange,  owner,  changer,  sectionid);
            _pageRepo.UpdatePage(page);


        }
    }
}
