using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.CategoryDtos;
using X.PagedList;

namespace Topic.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {

            var values = await _httpClient.GetFromJsonAsync<List<ResultCategoryWithBlogs>>("https://localhost:7074/api/Categories/GetActiveCategories");
            if (values != null)
            {
                ViewBag.count = values.Count;
            }

            return View(values.ToPagedList(pageNumber, 5));
        }
    }
}
