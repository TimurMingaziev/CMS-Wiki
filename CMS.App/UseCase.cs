using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Inf;
using CMS.Inf.Repository;
using CMS.Model;
using CMS.Model.Domain;
using AutoMapper;
using CMS.Data;
using NLog;

namespace CMS.App
{
    public class UseCase : IUseCase
    {
        PageRepository _pageRepo;
        SectionRepository _sectionRepo;
        CommentRepository _commentRepo;
        MarkRepository _markRepo;
        ILogger _logger;

        public UseCase(ILogger logger)
        {
            _logger = logger;
            _pageRepo = new PageRepository(_logger);
            _sectionRepo = new SectionRepository(_logger);
            _commentRepo = new CommentRepository(_logger);
            _markRepo = new MarkRepository(_logger);
        }

        public void CreateComment(object dtoObj)
        {
            try
            {
                var dto = (CommentDto) dtoObj;
                _logger.Info("UseCase : {0}", "start create comment");
                var comment = new Comment(dto.ContentComment,dto.OwnerComment,dto.PageId){};
                _logger.Info("UseCase : {0}", "adding to repository");
                _commentRepo.CreateComment(comment);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        public void CreateMark(object dtoObj)
        {
            try
            {
                _logger.Info("UseCase : {0}", "start create mark");
                var dto = (MarkDto) dtoObj;
                var mark = new Mark(dto.MarkThis,dto.OwnerMark,dto.DateMark,dto.PageId) {};
                _logger.Info("UseCase : {0}", "adding to repository");
                _markRepo.CreateMark(mark);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

        }

        public object CreatePage(object dtoObj)
        {
            PageDto dto=null;
            try
            {
                _logger.Info("UseCase : {0}", "start create page");
                dto = (PageDto) dtoObj;
                var page  = new Page(dto.NamePage,dto.ContentPage,dto.DateCreatePage, dto.DateChangePage,
                    dto.OwnerPage,dto.ChangerPage,dto.SectionId);
                _logger.Info("UseCase : {0}", "adding to repository");
                _pageRepo.CreatePage(page);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return dto;
        }


        public void CreateSection(object dtoObj)
        {
            try
            {
                _logger.Info("UseCase : {0}", "start create section");
                var dto = (SectionDto)dtoObj;
                var section = new Section(dto.NameSection, dto.DecriptionSection, dto.OwnerSection) {};
                _sectionRepo.CreateSection(section);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

        }

        public void UpdatePage(object objDto)
        {
            var page = new Page();
            //page.ChangePage( pageid,  name,  content,  datecreate,  datechange,  owner,  changer,  sectionid);
            _pageRepo.UpdatePage(page);


        }
    }
}
