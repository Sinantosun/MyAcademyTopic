﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Topic.WebUI.DAL;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var httpResponseMessage = await _httpClient.GetAsync("https://localhost:7074/api/Categories/GetCategories");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(result);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            string path = "/Category/";
            string fileName = ImageProcess.SetFileName(Path.GetExtension(createCategoryDto.formFile.FileName));
            createCategoryDto.ImageURL = "/Images/" + path + fileName;

            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent str = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:7074/api/Categories", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                ImageProcess.CreateImage(createCategoryDto.formFile, path, fileName);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"https://localhost:7074/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("awfawfawfaw");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"https://localhost:7074/api/Categories/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
        {
            string path = "/Category/";
            string fileName = "";
            if (model.ImageFile != null)
            {
                path = "/Category/";
                fileName = ImageProcess.SetFileName(Path.GetExtension(model.ImageFile.FileName));
                model.ImageURL = "/Images" + path + fileName;
            }

            var jsonData = JsonConvert.SerializeObject(model);

            StringContent str = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync("https://localhost:7074/api/Categories", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                if (model.ImageFile != null)
                {
                    ImageProcess.CreateImage(model.ImageFile, path, fileName);
                }

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
