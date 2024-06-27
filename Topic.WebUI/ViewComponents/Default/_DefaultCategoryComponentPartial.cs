using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultCategoryComponentPartial : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultCategoryComponentPartial(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7074/api/");
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("Categories/GetActiveCategories");
            return View(values);
        }

    }
}
