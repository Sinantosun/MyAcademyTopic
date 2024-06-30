using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinnesLayer.Abstract;
using Topic.DataAccsesLayer.Abstract;
using Topic.EntityLayer.Entities;

namespace Topic.BusinnesLayer.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public void TCreate(Questions entity)
        {
            _questionDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _questionDal.Delete(id);
        }

        public Questions TGetByFilter(Expression<Func<Questions, bool>> filter)
        {
           return _questionDal.GetByFilter(filter);
        }

        public Questions TGetById(int id)
        {
            return _questionDal.GetById(id);
        }

        public List<Questions> TGetList()
        {
            return _questionDal.GetList();
        }

        public List<Questions> TGetListByFilter(Expression<Func<Questions, bool>> filter)
        {
          return _questionDal.GetListByFilter(filter);
        }

        public void TUpdate(Questions entity)
        {
             _questionDal.Update(entity);
        }
    }
}
