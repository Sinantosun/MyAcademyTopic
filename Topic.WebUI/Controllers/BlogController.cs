using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.BlogDtos;

namespace Topic.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;

        public BlogController(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7074/api/");
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetBlogsByCategory(int id)
        {

            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>($"blogs/GetBlogsByCategoryID/{id}");
            return View(values);
        }


        public async Task<IActionResult> GetBlogsDetails(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<ResultBlogDto>($"Blogs/{id}");
            return View(value);
        }
          
    }
}
