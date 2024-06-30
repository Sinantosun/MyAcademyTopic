

using Topic.EntityLayer.Entities;

namespace Topic.DataAccsesLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {

        public List<Category> GetActiveCategoriesWithBlogs();

        int getAllCategoryCount();
        int getActiveCategoryCount();
      
    }
}
