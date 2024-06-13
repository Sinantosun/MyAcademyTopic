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
    public class EFBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public EFBlogDal(TopicContext topicContext) : base(topicContext)
        {
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _topicContext.Blogs.Include(t => t.Category).ToList();
        }
    }
}
