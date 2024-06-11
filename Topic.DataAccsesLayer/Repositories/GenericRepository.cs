using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccsesLayer.Abstract;
using Topic.DataAccsesLayer.Context;

namespace Topic.DataAccsesLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly TopicContext _topicContext;

        public GenericRepository(TopicContext topicContext)
        {
            _topicContext = topicContext;
        }

        public void Create(T entity)
        {
            _topicContext.Set<T>().Add(entity);
            _topicContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var value = GetById(id);
            _topicContext.Set<T>().Remove(value);
            _topicContext.SaveChanges();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _topicContext.Set<T>().FirstOrDefault(filter);
        }

        public T GetById(int id)
        {
            return _topicContext.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
           return _topicContext.Set<T>().ToList();
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _topicContext.Set<T>().Where(filter).ToList();
        }

        public void Update(T entity)
        {
            _topicContext.Set<T>().Update(entity);
            _topicContext.SaveChanges();
        }
    }
}
