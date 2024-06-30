using Microsoft.EntityFrameworkCore;
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

        public List<Category> GetActiveCategoriesWithBlogs()
        {
            return _topicContext.Categories.Include(f => f.Blogs).Where(t => t.Status == true).ToList();
        }

        public int getActiveCategoryCount()
        {
            return _topicContext.Categories.Where(t => t.Status == true).Count();
        }

        public int getAllCategoryCount()
        {
            return _topicContext.Categories.Count();
        }
    }
}
