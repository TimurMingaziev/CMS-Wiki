using System;
using System.Collections.Generic;
using System.Linq;
using CMS.Model;
using NLog;

namespace CMS.Inf.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        public void Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
           
            using (var context = new UserContext())
            {
                return context.Set<T>().ToList();
                
           }
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
