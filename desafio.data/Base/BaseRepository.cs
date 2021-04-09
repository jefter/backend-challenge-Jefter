using desafio.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace desafio.data.Base
{
    public abstract class BaseRepository<T> : IRepository<T>
      where T : EntityBase
    {

        protected DesafioContext _context = null;
        protected DbSet<T> table = null;

        public BaseRepository()
        {
            this._context = new DesafioContext();
            table = _context.Set<T>();

        }

        public virtual void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            this.Save();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return table.ToList<T>();
        }


        public virtual T GetById(object id)
        {
            return table.Find(id);
        }

        public virtual void Insert(T entity)
        {
            table.Add(entity);
            this.Save();
        }

        public virtual void Update(T entity)
        {

            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            this.Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
