using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultBlogComponentPartial : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultBlogComponentPartial(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7074/api/");
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var categories = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            ViewBag.Categories = categories;    

            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }
    }
}
