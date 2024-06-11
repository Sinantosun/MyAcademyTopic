using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Topic.BusinnesLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetList();
        T TGetById(int id);
        void TDelete(int id);
        void TUpdate(T entity);
        void TCreate(T entity);

        List<T> TGetListByFilter(Expression<Func<T, bool>> filter);
        T TGetByFilter(Expression<Func<T, bool>> filter);
    }
}
