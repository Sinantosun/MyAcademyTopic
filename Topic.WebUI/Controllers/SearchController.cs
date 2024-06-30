using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.BlogDtos;
using X.PagedList;

namespace Topic.WebUI.Controllers
{
    public class SearchController : Controller
    {
        private readonly HttpClient _httpClient;

        public SearchController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageNumber = 1)
        {
            var value = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>($"https://localhost:7074/api/Blogs/GetBlogsByKeyword/{keyword}");
            ViewBag.Keyword = keyword;

            if (value != null)
            {
                ViewBag.count = value.Count;
            }

            return View(value.ToPagedList(pageNumber, 3));
        }
    }
}
