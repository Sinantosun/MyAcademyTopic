using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.BusinnesLayer.Abstract;
using Topic.DataAccsesLayer.Abstract;
using Topic.EntityLayer.Entities;

namespace Topic.BusinnesLayer.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
       
        private readonly IBlogDal _blogDal;



        public BlogManager(IGenericDal<Blog> genericDal, IBlogDal blogDal) : base(genericDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> TGetBlogsByCategoryId(int id)
        {
          return _blogDal.GetBlogsByCategoryId(id);
        }

        public List<Blog> TGetBlogsWithCategories()
        {
            return _blogDal.GetBlogsWithCategories();
        }

        public Blog TGetBlogWithCategoryById(int id)
        {
            return _blogDal.GetBlogWithCategoryById(id);
        }
    }
}
