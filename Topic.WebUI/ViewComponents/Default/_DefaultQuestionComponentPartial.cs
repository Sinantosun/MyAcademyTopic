using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.QuestionDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultQuestionComponentPartial : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public _DefaultQuestionComponentPartial(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultQuestionDto>>("https://localhost:7074/api/Questions");
            return View(values);
        }
    }
}
