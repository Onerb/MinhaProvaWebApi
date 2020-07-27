using MinhaApi.Business;
using MinhaApi.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaApi.Data
{
    public class Repository_old<T> : IGenericRepository<T> where T : Entity, new()
    {
        public Task<int> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
