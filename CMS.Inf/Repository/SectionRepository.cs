﻿using System.Linq;
using CMS.Data;
using CMS.Model.Domain;
using AutoMapper;
using System;
using NLog;

namespace CMS.Inf.Repository
{
    public class SectionRepository : Repository<Section>
    {
        UserContext _userContext;
        IConfigurationProvider _config;
        ILogger _logger;
        public SectionRepository(ILogger logger)
        {
            _logger = logger;
            _userContext = new UserContext();
            _config = new MapperConfiguration(cfg => cfg.CreateMap<Section, SectionDto>());
        }
        public Section GetSectionById(int id)
        {
             return _userContext.Set<Section>().FirstOrDefault(x => x.SectionId == id);
        }

        public void CreateSection(Section section)
        {
            try
            {
                var dest = _config.CreateMapper().Map<Section, SectionDto>(section);
                _userContext.Section.Add(dest);
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
