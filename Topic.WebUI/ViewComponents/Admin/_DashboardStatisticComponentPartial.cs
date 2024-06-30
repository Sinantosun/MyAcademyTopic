using Microsoft.AspNetCore.Mvc;

namespace Topic.WebUI.ViewComponents.Admin
{
    public class _DashboardStatisticComponentPartial : ViewComponent
    {

        private readonly HttpClient _httpClient;

        public _DashboardStatisticComponentPartial(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessageForBlogCount = await _httpClient.GetAsync("https://localhost:7074/api/Blogs/GetBlogCount");
            if (responseMessageForBlogCount.IsSuccessStatusCode)
            {
                var result = await responseMessageForBlogCount.Content.ReadAsStringAsync(); 
                ViewBag.BlogCount = result; 
            }

            var responseMessageForAllCategoryCount = await _httpClient.GetAsync("https://localhost:7074/api/Categories/GetAllCategoryCount");
            if (responseMessageForAllCategoryCount.IsSuccessStatusCode)
            {
                var result = await responseMessageForAllCategoryCount.Content.ReadAsStringAsync();
                ViewBag.AllCategoryCount = result;
            }


            var responseMessageForActiveCategoryCount = await _httpClient.GetAsync("https://localhost:7074/api/Categories/GetActiveCategoryCount");
            if (responseMessageForActiveCategoryCount.IsSuccessStatusCode)
            {
                var result = await responseMessageForActiveCategoryCount.Content.ReadAsStringAsync();
                ViewBag.ActiveCategoryCount = result;
            }

            return View();
        }
    }
}
