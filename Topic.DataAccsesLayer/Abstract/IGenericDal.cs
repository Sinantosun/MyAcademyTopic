using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Topic.DataAccsesLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetList();
        T GetById(int id);
        void Delete(int id);
        void Update(T entity);
        void Create(T entity);

        List<T> GetListByFilter(Expression<Func<T, bool>> filter);  
        T GetByFilter(Expression<Func<T, bool>> filter);  
    }
}
