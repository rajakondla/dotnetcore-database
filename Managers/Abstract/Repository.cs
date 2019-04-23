using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.Abstract;
using Data.Concrete;
using DotNetCoreWebAPI;

namespace Managers.Abstract
{
    public abstract class Repository<T,C>:IRepository<T> where T:EntityBase where C:DbContext
    {
        C _context;
        protected Repository(C context)
        {
            _context = context;
        }

        public IQueryable<T> All()
        {
            return _context.Set<T>();
           // return 
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void AddAndSave(T obj)
        {
            Add(obj);
            _context.SaveChanges();
        }   

        public void Add(T obj)
        {
            _context.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public T Find(long Id)
        {
            return null;
        }

        public void Dispose()
        {

        }

    }

}
