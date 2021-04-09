using desafio.data.Base;
using desafio.domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace desafio.service.Base
{
    public abstract class ServiceBase<T, R> : IServices<T>
    where T : EntityBase
    where R : IRepository<T>, new()
    {
        protected R repository;

        public ServiceBase()
        {
            repository = new R();
        }

        public virtual void Delete(int id)
        {
            try
            {
                repository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual T GetById(object id)
        {
            try
            {
                return repository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void Insert(T entity)
        {
            try
            {
                repository.Insert(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                repository.Update(entity);

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
