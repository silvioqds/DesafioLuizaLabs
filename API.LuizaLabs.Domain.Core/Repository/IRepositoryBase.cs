using API.LuizaLabs.Domain.Models;
using System.Collections.Generic;


namespace API.LuizaLabs.Domain.Core.Repository
{
    public interface IRepositoryBase<T> where T : Base
    {
        T Get(int ID);

        IEnumerable<T> GetAll();

        void Save(T obj);

        void Update(T obj);

        void Remove(T obj);

        void Dispose();

    }
}
