using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccsesLayer.Abstract;
using Topic.DataAccsesLayer.Context;
using Topic.DataAccsesLayer.Repositories;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccsesLayer.Concrete
{
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EFCategoryDal(TopicContext topicContext) : base(topicContext)
        {
        }
    }
}
