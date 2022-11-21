using RegisterApi.Domain.Dtos;
using System.Drawing;

namespace RegisterApi.Domain.Helper
{
    public static class ImageEdit 
    {
        public static byte[] ImageResize(ImageDto image)
        {
            Image result = Image.FromStream(image.Image.OpenReadStream(), true, true);
            var newImage = new Bitmap(200, 200);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(result, 0, 0, 200, 200);
            }
            ImageConverter converter = new ImageConverter();
            var resized = (byte[])converter.ConvertTo(newImage, typeof(byte[]));

            return resized;
        }
    }
}
