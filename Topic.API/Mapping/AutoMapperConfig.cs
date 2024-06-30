using AutoMapper;
using Topic.DtoLayer.BlogDtos;
using Topic.DtoLayer.CategoryDtos;
using Topic.DtoLayer.ManuelDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Blog, CreateBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();
            CreateMap<Blog, ResultBlogDto>().ReverseMap();
            CreateMap<Blog, ResultBlogForSearchDto>().ReverseMap();


            CreateMap<Manuel, ResultManuelDto>().ReverseMap();
            CreateMap<Manuel, CreateManuelDto>().ReverseMap();
            CreateMap<Manuel, UpdateManuelDto>().ReverseMap();
        }
    }
}
