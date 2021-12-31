using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Domain.Core.Service
{
    public interface IServiceBase<T> : IDisposable where T : class
    {
        T Get(int ID);

        IEnumerable<T> GetAll();

        void Save(T obj);

        void Update(T obj);

        void Remove(T obj);

    }
}
