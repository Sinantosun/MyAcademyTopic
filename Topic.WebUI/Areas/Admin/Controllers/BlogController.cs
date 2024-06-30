using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Topic.WebUI.DAL;
using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;

        public BlogController(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7074/api/");
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");

            return View(values);
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _httpClient.DeleteAsync("blogs/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            var categoryList = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("Categories");

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString(),
                                               }).ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto model)
        {
            string path = "/Blog/";
            string CoverPhotoFileName = ImageProcess.SetFileName(Path.GetExtension(model.CoverPhotoFile.FileName));
            string Image1FileName = ImageProcess.SetFileName(Path.GetExtension(model.Image1File.FileName));
            string Image2FileName = ImageProcess.SetFileName(Path.GetExtension(model.Image2File.FileName));

            ImageProcess.CreateImage(model.CoverPhotoFile, path, CoverPhotoFileName);
            ImageProcess.CreateImage(model.Image1File, path, Image1FileName);
            ImageProcess.CreateImage(model.Image2File, path, Image2FileName);

            model.CoverImageUrl = "/Images/" + path + CoverPhotoFileName;
            model.Image1 = "/Images/" + path + Image1FileName;
            model.Image2 = "/Images/" + path + Image2FileName;


            await _httpClient.PostAsJsonAsync("blogs", model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateBlogDto>("blogs/" + id);

            var categoryList = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("Categories");

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString(),
                                               }).ToList();
            ViewBag.Categories = categories;

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto model)
        {
            string path = "/Blog/";
            string fileName = "";
            if (model.CoverPhotoFile != null)
            {
                fileName = ImageProcess.SetFileName(Path.GetExtension(model.CoverPhotoFile.FileName));
                model.CoverImageUrl = "/Images" + path + fileName;

                ImageProcess.CreateImage(model.CoverPhotoFile, path, fileName);
            
            }

            if (model.Image1File != null)
            {
                fileName = ImageProcess.SetFileName(Path.GetExtension(model.Image1File.FileName));
                model.Image1 = "/Images" + path + fileName;

                ImageProcess.CreateImage(model.Image1File, path, fileName);
  
            }

            if (model.Image2File != null)
            {
                fileName = ImageProcess.SetFileName(Path.GetExtension(model.Image2File.FileName));
                model.Image2 = "/Images" + path + fileName;
                ImageProcess.CreateImage(model.Image2File, path, fileName);
            }
            await _httpClient.PutAsJsonAsync("blogs", model);
            return RedirectToAction("Index");
        }
    }
}
