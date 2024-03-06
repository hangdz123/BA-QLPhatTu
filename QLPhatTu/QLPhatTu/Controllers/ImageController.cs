using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLPhatTu.Entities;
using QLPhatTu.IServices;
using QLPhatTu.Services;

namespace QLPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        //private readonly IDaoTrangServices services;
        private readonly AppDbContext dbContext;
        static string cloudName = "dudsmuj3u";
        static string apiKey = "191975596474664";
        static string apiSecret = "CCJOoTX1oRWtD26btaG2GF9jjdM";
        static public Account account = new Account(cloudName, apiKey, apiSecret);
        static public Cloudinary _cloudinary = new Cloudinary(account);
        public ImageController()
        {
            //services = new DaoTrangServices();
            dbContext = new AppDbContext();
        }
        [HttpPost]
        public async Task<IActionResult> AddImage(string tenTaiKhoan, [FromForm] IFormFile photo)
        {
            var canTim = dbContext.PhatTu.SingleOrDefault(x=>x.TenTaiKhoan == tenTaiKhoan);
            if (canTim == null || photo == null || photo.Length == 0)
            {
                return BadRequest("Thất Bại");
            }

            string filePath = Path.Combine("Upload", canTim.TenTaiKhoan + Path.GetExtension(photo.FileName));
            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            canTim.AnhChup = "/Image/" + canTim.Id + "_" + canTim.TenTaiKhoan;
            dbContext.PhatTu.Update(canTim);
            await dbContext.SaveChangesAsync();

            using (var stream = photo.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(photo.FileName, stream),
                    PublicId = canTim.Id + "_" + canTim.TenTaiKhoan,
                    Transformation = new Transformation().Width(300).Height(400).Crop("fill")
                };
                await _cloudinary.UploadAsync(uploadParams);
                
            }

            return Ok("Thêm ảnh thành công");
        }
    }
}
