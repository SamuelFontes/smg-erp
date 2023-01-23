using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.IService
{
    public interface IGeneric
    {
        Task<List<T>> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> Add<T>(T model);
        Task<bool> Update<T>(T model);
        Task<bool> Delete<T>(T model);
    }
}
