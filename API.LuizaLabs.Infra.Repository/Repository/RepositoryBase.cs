using API.LuizaLabs.Data;
using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.LuizaLabs.Infra.Repository.Repository
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : Base
    {

        private readonly SQLContext _context;

        public RepositoryBase(SQLContext context)
        {
            this._context = context;
        }

        public T Get(int ID)
        {
            return _context.Set<T>().Find(ID);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Save(T obj)
        {
            try
            {
                _context.Set<T>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(T obj)
        {
            try
            {
                _context.Set<T>().Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
