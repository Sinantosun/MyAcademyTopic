using Microsoft.AspNetCore.Http;

namespace Topic.WebUI.DAL
{
    public static class ImageProcess
    {
        public static async void CreateImage(IFormFile req, string path,string fileName)
        {

            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images" + path, fileName);
            var stream = new FileStream(location, FileMode.Create);
            await req.CopyToAsync(stream);

         
        
        }


        public static string SetFileName(string ex)
        {
           return Guid.NewGuid().ToString() + ex;
        }
    }
}
