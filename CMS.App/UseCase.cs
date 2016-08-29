﻿using System;
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

        public object CreatePage(object dtoObj)
        {
            PageDto dto=null;
            try
            {
                _logger.Info("UseCase : {0}", "start create page");
                dto = (PageDto) dtoObj;
                var page = new Page
                {
                    NamePage = dto.NamePage,
                    ChangerPage = dto.ChangerPage,
                    ContentPage = dto.ContentPage,
                    DateChangePage = dto.DateChangePage,
                    DateCreatePage = dto.DateCreatePage,
                    OwnerPage = dto.OwnerPage,
                    SectionId = dto.SectionId
                };
                _logger.Info("UseCase : {0}", "adding to repository");
                _pageRepo.CreatePage(page);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            return dto;
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
