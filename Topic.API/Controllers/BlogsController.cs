using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinnesLayer.Abstract;
using Topic.DtoLayer.BlogDtos;
using Topic.EntityLayer.Entities;
using X.PagedList;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            var values = _blogService.TGetBlogsWithCategories();
            var categories = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(categories);
        }

        [HttpGet("GetBlogsByKeyword/{keyword}")]
        public IActionResult GetBlogsByKeyword(string keyword)
        {
            var values = _blogService.TGetBlogBySearchKeyword(keyword);
            return Ok(values);
        }

        [HttpGet("GetBlogsForAutoComplate/{keyword}")]
        public IActionResult GetBlogsForAutoComplate(string keyword)
        {
            var values = _blogService.TGetBlogsNameForAutoComplate(keyword).Select(item => new ResultBlogForSearchDto
            {
                label = item.label,
            });

            return Ok(values);
        }

        [HttpGet("GetBlogsByCategoryID/{id}")]
        public IActionResult GetBlogsByCategoryID(int id)
        {
            var values = _blogService.TGetBlogsByCategoryId(id);
            var categories = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetblogById(int id)
        {
            var value = _blogService.TGetBlogWithCategoryById(id);
            var blog = _mapper.Map<ResultBlogDto>(value);
            return Ok(blog);
        }

        [HttpDelete("{id}")]
        public IActionResult Deleteblog(int id)
        {
            _blogService.TDelete(id);
            return Ok("Blog Silindi");
        }

        [HttpPost]
        public IActionResult Createblog(CreateBlogDto model)
        {
            var blog = _mapper.Map<Blog>(model);
            _blogService.TCreate(blog);
            return Ok("Kayıt eklendi");
        }

        [HttpPut]
        public IActionResult Updateblog(UpdateBlogDto model)
        {
            var blog = _mapper.Map<Blog>(model);
            _blogService.TUpdate(blog);
            return Ok("Kayıt Güncellendi");
        }
    }
}
