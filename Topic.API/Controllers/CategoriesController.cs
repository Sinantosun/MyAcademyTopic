using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinnesLayer.Abstract;
using Topic.DtoLayer.CategoryDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = _categoryService.TGetActiveCategoriesWithBlogs();
            List<ResultCategoryWithBlogs> result = new List<ResultCategoryWithBlogs>();
            foreach (var item in values)
            {
                result.Add(new ResultCategoryWithBlogs
                {
                    BlogCount = item.Blogs.Count,   
                    CategoryID = item.CategoryID,
                    CategoryName = item.CategoryName,
                    Description = item.Description,
                    ImageURL = item.ImageURL,
                    Status = item.Status,
                });
            }
            return Ok(result);
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            var values = _categoryService.TGetList();
            return Ok(values);
        }


        [HttpGet("GetAllCategoryCount")]
        public IActionResult GetAllCategoryCount()
        {
            var values = _categoryService.TgetAllCategoryCount();
            return Ok(values);
        }

        [HttpGet("GetActiveCategoryCount")]
        public IActionResult GetActiveCategoryCount()
        {
            var values = _categoryService.TgetActiveCategoryCount();
            return Ok(values);
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var values = _categoryService.TGetListByFilter(t=>t.Status==true);
            var categories = _mapper.Map<List<ResultCategoryDto>>(values);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var value = _categoryService.TGetById(id);
            var category = _mapper.Map<ResultCategoryDto>(value);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori Silindi");
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            _categoryService.TCreate(category);
            return Ok("Kayıt eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto model)
        {
            var category = _categoryService.TGetById(model.CategoryID);
            category.Status = model.Status;

            if (model.ImageURL != null)
            {
                category.ImageURL = model.ImageURL;
            }
            category.CategoryName = model.CategoryName;
            category.Description = model.Description;

            _categoryService.TUpdate(category);
            return Ok("Kayıt Güncellendi");
        }
    }
}
