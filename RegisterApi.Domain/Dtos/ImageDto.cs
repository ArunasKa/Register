using Microsoft.AspNetCore.Http;
using RegisterApi.Domain.Validation;

namespace RegisterApi.Domain.Dtos
{
    public class ImageDto
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtentions(new[] { ".png", ".jpg" })]
        public IFormFile Image { get; set; }
    }
}
