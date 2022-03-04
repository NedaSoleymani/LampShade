using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace _0_Framwork.Domain
{
    public interface IRepository<Tkey, T> where T :class
    {
        T Get(Tkey id);
        List<T> Get();
        void Create(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
        void SaveChange();
    }
}
