
using Topic.EntityLayer.Entities;

namespace Topic.DataAccsesLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetBlogsWithCategories();
    }
}
