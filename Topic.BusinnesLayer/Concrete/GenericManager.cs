using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinnesLayer.Abstract;
using Topic.DataAccsesLayer.Abstract;

namespace Topic.BusinnesLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void TCreate(T entity)
        {
            _genericDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _genericDal.Delete(id);
        }

        public T TGetByFilter(Expression<Func<T, bool>> filter)
        {
           return _genericDal.GetByFilter(filter);
        }

        public T TGetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public List<T> TGetList()
        {
            return _genericDal.GetList();
        }

        public List<T> TGetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _genericDal.GetListByFilter(filter);
        }

        public void TUpdate(T entity)
        {
            _genericDal.Update(entity);
        }
    }
}
