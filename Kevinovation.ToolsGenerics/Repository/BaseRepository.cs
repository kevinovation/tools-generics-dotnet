using Kevinovation.ToolsGenerics.Models.Interface;
using Kevinovation.ToolsGenerics.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kevinovation.ToolsGenerics.Repository
{
    public abstract class BaseRepository<M> : IBaseRepository<M> where M : class, IEntity
    {
        protected DbContext Db { get; }
        private DbSet<M> table = null;

        protected DbSet<M> Table
        {
            get
            {
                return this.table;
            }
        }

        public BaseRepository(DbContext dbContext)
        {
            this.Db = dbContext;
            this.table = Db.Set<M>();
        }

        public void Delete(int id)
        {
            M existing = this.SelectByID(id);
            if (existing != null)
                this.table.Remove(existing);
        }

        public void Delete(M m)
        {
            this.table.Remove(m);
            this.Save();
        }

        public void Insert(M obj)
        {
            this.table.Add(obj);
            this.Save();
        }

        public void Save()
        {
            this.Db.SaveChanges();
        }

        public IEnumerable<M> SelectAll()
        {
            return table.ToList();
        }

        public M SelectByID(int id)
        {
            return table.FirstOrDefault(m => m.Id == id);
        }

        public void Update(M obj)
        {
            table.Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
            this.Save();
        }
    }
}
