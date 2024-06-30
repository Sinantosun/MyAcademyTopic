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
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> TGetActiveCategoriesWithBlogs()
        {
            return _categoryDal.GetActiveCategoriesWithBlogs();
        }

        public int TgetActiveCategoryCount()
        {
            return _categoryDal.getActiveCategoryCount();
        }

        public int TgetAllCategoryCount()
        {
            return _categoryDal.getAllCategoryCount();
        }
    }
}
