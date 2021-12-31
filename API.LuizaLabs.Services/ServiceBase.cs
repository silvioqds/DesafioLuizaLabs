using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Core.Service;
using System;
using System.Collections.Generic;

namespace API.LuizaLabs.Services
{
    public abstract class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {

        private readonly IRepositoryBase<T> _repository;


        public ServiceBase(IRepositoryBase<T> repository)
        {
            this._repository = repository;
        }
       
        public virtual T Get(int ID)
        {
            return _repository.Get(ID);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(T obj)
        {
            _repository.Remove(obj);
        }

        public void Save(T obj)
        {
           _repository.Save(obj);
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }

        public void Dispose()
        {
            _repository.Dispose(); 
        }
    }
}
