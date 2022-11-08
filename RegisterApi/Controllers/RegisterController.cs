using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterApi.BL.Interfaces;
using RegisterApi.Domain.Dtos;
using RegisterApi.Domain.Models;
using System.Drawing;

namespace RegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        //[Authorize]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="Admin")]
        [HttpPost("Update username")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateUserName(int id, string name)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            userToUpdate.Name = name;

            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
        [HttpPost("Update lastname")]
        public async Task<ActionResult> UpdateLastName(int id, string lastName)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            userToUpdate.LastName = lastName;
            
            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
        [HttpPost("Update Phone number")]
        public async Task<ActionResult> UpdateEmail(int id, int phoneNumber)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            userToUpdate.PhoneNumber = phoneNumber;

            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
        [HttpPost("Update PersonalCode")]
        public async Task<ActionResult> UpdatePersonalCode(int id, int personalCode)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            userToUpdate.PersonalCode = personalCode;

            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
         [HttpPost("Update Email")]
        public async Task<ActionResult> UpdateEmail(int id, string email)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            userToUpdate.Email = email;

            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
        [HttpPost("Update Photo")]
        public async Task<ActionResult> UpdatePhoto(int id, [FromForm]ImageDto image)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            Image result = Image.FromStream(image.Image.OpenReadStream(), true, true);
            var newImage = new Bitmap(200, 200);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(result, 0, 0, 200, 200);
            }
            ImageConverter converter = new ImageConverter();
            var resized =  (byte[])converter.ConvertTo(newImage, typeof(byte[]));

            userToUpdate.ImageBytes = resized;
            userToUpdate.ImageFileName = image.Image.FileName;
            userToUpdate.ImageContentType = image.Image.ContentType;

            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
        [HttpPost("Update City")]
        public async Task<ActionResult> UpdateCity(int id, string city)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            userToUpdate.HomeAddress.City = city;

            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
        [HttpPost("Update StreetName")]
        public async Task<ActionResult> UpdateStreetName(int id, string StreetName)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            userToUpdate.HomeAddress.StreetName = StreetName;

            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
        [HttpPost("Update HouseNumber")]
        public async Task<ActionResult> UpdateHouseNumber(int id, string HouseNumber)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            userToUpdate.HomeAddress.HouseNumber = HouseNumber;

            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
        [HttpPost("Update ApartmentNumber")]
        public async Task<ActionResult> UpdateApartmentNumber(int id, string ApartmentNumber)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            userToUpdate.HomeAddress.ApartmentNumber = ApartmentNumber;

            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
        [HttpGet("DownloadPicture")]
        public async Task<ActionResult> DownloadImage([FromQuery] int id)
        {
            var image = await _registerService.GetPersonByIdAsync(id);
            return File(image.ImageBytes, image.ImageContentType);
        }
        [HttpGet("Get All info by id")]
        public async Task<ActionResult> GetAllInfoById(int id)
        {
            var user = await _registerService.GetPersonByIdAsync(id);
            if (user == null)
                return BadRequest("No user by id");
            return Ok(user);
        }
        //[HttpDelete("Delete User")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var user = await _registerService.GetPersonByIdAsync(id);
        //    if (user == null)
        //        return BadRequest("No user by id");
        //    _registerService.DeleteUserAsync(id);
        //    return Ok("User Deleted");
        //}
    }
}
