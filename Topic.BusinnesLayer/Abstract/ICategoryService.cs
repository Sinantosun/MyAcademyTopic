using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccsesLayer.Context;
using Topic.EntityLayer.Entities;

namespace Topic.BusinnesLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        List<Category> TGetActiveCategoriesWithBlogs();

        public int TgetActiveCategoryCount();
        public int TgetAllCategoryCount();
       
    }
}
