using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.ManuelDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultManuelComponentPartial:ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultManuelComponentPartial(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7074/api/");
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultManuelDto>>("Manuels");
            return View(values);
        }
    }
}
