using Kevinovation.ToolsGenerics.Models.Interface;
using Kevinovation.ToolsGenerics.Repository.Interface;
using Kevinovation.ToolsGenerics.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kevinovation.ToolsGenerics.Service
{
    public abstract class BaseServiceRepository<M> : IBaseServiceRepository<M> where M : class, IEntity
    {
        private IBaseRepository<M> _repository;

        public BaseServiceRepository(IBaseRepository<M> repository)
        {
            _repository = repository;
        }

        public IEnumerable<M> GetAll()
        {
            return this._repository.SelectAll();
        }

        public M GetByID(int id)
        {
            return this._repository.SelectByID(id);
        }

        public M Create(M obj)
        {
            this._repository.Insert(obj);
            this.Save();
            return obj;
        }

        public virtual M Update(M obj)
        {
            this._repository.Update(obj);
            this.Save();
            return obj;
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
            this.Save();
        }

        public void Save()
        {
            this._repository.Save();
        }
    }
}
