using Kevinovation.ToolsGenerics.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kevinovation.ToolsGenerics.Repository.Interface
{
    public interface IBaseRepository<M> where M : class, IEntity
    {
        IEnumerable<M> SelectAll();

        M SelectByID(int id);

        void Insert(M obj);

        void Update(M obj);

        void Delete(int id);

        void Save();
    }
}
