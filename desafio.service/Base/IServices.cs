using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.service.Base
{
    public interface IServices<T>
    {
        void Insert(T entity);

        void Delete(int id);

        void Update(T entity);

        T GetById(object id);

        IEnumerable<T> GetAll();

    }
}
