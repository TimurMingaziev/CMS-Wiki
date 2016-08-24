using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Data;
using CMS.Model.Domain;
using AutoMapper;
using NLog;

namespace CMS.Inf.Repository
{
    public class CommentRepository : Repository<CommentDto>
    {
        UserContext _userContext;
        IConfigurationProvider _config;
        ILogger _logger;
        public CommentRepository(ILogger logger)
        {
            _logger = logger;
            _userContext = new UserContext();
            _config = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDto>());
        }

        public void CreateComment(Comment comment)
        {
            try
            {
                var dest = _config.CreateMapper().Map<Comment, CommentDto>(comment);
                _userContext.Comment.Add(dest);
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
