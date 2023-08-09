using CasgemMicroservice.PhotoStock.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoStocksController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SavePhoto(IFormFile file,CancellationToken cancellationToken)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", file.FileName);
            if (file != null && file.Length>0)
            {
                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream,cancellationToken);
                var returnPath=file.FileName;
                PhotoDto photo = new PhotoDto
                {
                    ImageUrl = returnPath
                };
                return Ok("Fotoğraf başarıyla kaydedildi.");
            }
            return NoContent();
        }
    } 
}
