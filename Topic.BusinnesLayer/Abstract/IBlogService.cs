using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.DtoLayer.BlogDtos;
using Topic.EntityLayer.Entities;

namespace Topic.BusinnesLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> TGetBlogsWithCategories();

        List<Blog> TGetBlogsByCategoryId(int id);
        Blog TGetBlogWithCategoryById(int id);

        List<Blog> TGetBlogBySearchKeyword(string keyword);

        List<ResultBlogForSearchDto> TGetBlogsNameForAutoComplate(string keyword);


    }
}
