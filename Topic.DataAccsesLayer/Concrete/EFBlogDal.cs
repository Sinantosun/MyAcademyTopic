﻿using Microsoft.EntityFrameworkCore;
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

        public List<Blog> GetBlogsByCategoryId(int id)
        {
            return _topicContext.Blogs.Where(x => x.CategoryID == id).ToList();
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _topicContext.Blogs.Include(t => t.Category).ToList();
        }

        public Blog GetBlogWithCategoryById(int id)
        {
            return _topicContext.Blogs.Include(t => t.Category).FirstOrDefault(x => x.BlogID == id);
        }
    }
}
