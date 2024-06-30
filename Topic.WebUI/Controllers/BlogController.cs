using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.BlogDtos;
using X.PagedList;

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

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            if (values != null)
            {
                ViewBag.BlogCount = values.Count();
            }
            return View(values.ToPagedList(pageNumber, 5));
        }

        public async Task<IActionResult> GetBlogsByCategory(int id,int pageNumber=1)
        {

            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>($"blogs/GetBlogsByCategoryID/{id}");
            return View(values.ToPagedList(pageNumber,5));
        }


        public async Task<IActionResult> GetBlogsDetails(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<ResultBlogDto>($"Blogs/{id}");
            return View(value);
        }

    }
}
