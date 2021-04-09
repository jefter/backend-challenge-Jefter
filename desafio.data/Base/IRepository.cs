using desafio.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.data.Base
{
    public interface IRepository<T> where T : EntityBase
    {
        void Insert(T entity);

        void Delete(int id);

        void Update(T entity);

        T GetById(object id);

        IEnumerable<T> GetAll();

    }
}
