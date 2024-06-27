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
            var values = _categoryService.TGetListByFilter(x => x.Status == true);
            return Ok(values);
        }


        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var values = _categoryService.TGetList();
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
            var category = _mapper.Map<Category>(model);
            _categoryService.TUpdate(category);
            return Ok("Kayıt Güncellendi");
        }
    }
}
