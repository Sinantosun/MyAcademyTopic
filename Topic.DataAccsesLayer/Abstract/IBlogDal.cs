
using Topic.DtoLayer.BlogDtos;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccsesLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetBlogsWithCategories();

        List<Blog> GetBlogsByCategoryId(int id);

        Blog GetBlogWithCategoryById(int id);

        List<Blog> GetBlogBySearchKeyword(string keyword);


        List<ResultBlogForSearchDto> GetBlogsNameForAutoComplate(string keyword);

        int getBlogCount();

 




    }
}
