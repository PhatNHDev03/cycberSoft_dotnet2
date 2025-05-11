using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using session40_52.Models;
using SixLabors.ImageSharp;

namespace session40_52.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly FileUploadSettings _settings;
        private readonly IWebHostEnvironment _env; // lay file ve luu

        public UploadController(IOptions<FileUploadSettings> settings, IWebHostEnvironment env)
        {
            _settings = settings.Value;
            _env = env;
        }

        [HttpPost("image")]
        public async Task<ActionResult> UploadFile(IFormFile file)
        {
            try
            {
                //kiem tra null
                if (file == null || file.Length == 0) return BadRequest("File is null or empty");
                //kiem tra file vuot qua duong dan 
                if (file.Length > _settings.MaxFileSize) return BadRequest("File is too large");
                //kiem tra dinh dang file
                //lay duoi file
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (_settings.AllowedExtensions.Contains(extension) == false) return BadRequest("Invalid file extension");
                //tao ten file tr khi luu vao prj
                var fileName = $"({Guid.NewGuid().ToString()}){extension}";
                // weddrootpath lay duong dan tuyet doi cua wwwroot
                var UploadPath = Path.Combine(_env.WebRootPath, _settings.UploadPath);
                // luu file
                //tao folder uploads neu nhu ko ton tai
                if (!Directory.Exists(UploadPath)) Directory.CreateDirectory(UploadPath);
                var image = await Image.LoadAsync(file.OpenReadStream());
                //luu file vao uploads
                var filePath = Path.Combine(UploadPath, fileName);
                await image.SaveAsync(filePath);
                return Ok(new UploadResponse { Success = true, Message = "file Upload success", FilePath = filePath });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}