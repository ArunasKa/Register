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
        // daugiau logikos is controller layer i business logic layer?
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost("Update username")]
        public async Task<ActionResult> UpdateUserName(int id, string username)
        {//could be with http status to get code from service with all checks for data and if status 200 then update
            var userToUpdate = await _registerService.GetUserIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdateUsernameAsync(id, username);
            return Ok();
        }

        [HttpPost("Update name")]
        public async Task<ActionResult> UpdateName(int id, string name)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdateNameAsync(id, name);
            return Ok();
        }
        [HttpPost("Update lastname")]
        public async Task<ActionResult> UpdateLastName(int id, string lastName)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdateLastNameAsync(id, lastName);
            return Ok();
        }
        [HttpPost("Update PersonalCode")]
        public async Task<ActionResult> UpdatePersonalCode(int id, int personalCode)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdatePersonalCodeAsync(id, personalCode);
            return Ok();
        }
        [HttpPost("Update Phone number")]
        public async Task<ActionResult> UpdatePhoneNumber(int id, int phoneNumber)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdatePhoneNumberAsync(id, phoneNumber);
            return Ok();
        }
        [HttpPost("Update Email")]
        public async Task<ActionResult> UpdateEmail(int id, string email)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdateEmailAsync(id, email);
            return Ok();
        }
        [HttpPost("Update Photo")]
        //Quit program before starting end point(Only on wrong browser(Chrome is fine))?
        public async Task<ActionResult> UpdatePhoto(int id,[FromForm]ImageDto image)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdatePhotoAsync(id, image);
            return Ok();
        }
        [HttpPost("Update City")]
        public async Task<ActionResult> UpdateCity(int id, string city)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdateCityAsync(id, city);
            return Ok();
        }
        [HttpPost("Update StreetName")]
        public async Task<ActionResult> UpdateStreetName(int id, string StreetName)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdateStreetNameAsync(id, StreetName);
            return Ok();
        }
        [HttpPost("Update HouseNumber")]
        public async Task<ActionResult> UpdateHouseNumber(int id, string HouseNumber)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdateHouseNumberAsync(id, HouseNumber);
            return Ok();
        }
        [HttpPost("Update ApartmentNumber")]
        public async Task<ActionResult> UpdateApartmentNumber(int id, string ApartmentNumber)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");

            await _registerService.UpdateApartmentNumberAsync(id, ApartmentNumber);
            return Ok();
        }
        [HttpGet("DownloadPicture")]
        public async Task<ActionResult> DownloadImage([FromQuery] int id)
        {
            var image = await _registerService.GetPersonByIdAsync(id);
            if(image == null)
                return BadRequest("No user by id");
            return File(image.ImageBytes, image.ImageContentType);
            
             
        }
        [HttpGet("Get All info by id")]
        public async Task<ActionResult<Person>> GetAllInfoById(int id)
        {
            var user = await _registerService.GetPersonByIdAsync(id);
            if (user == null)
                return BadRequest("No user by id");
            return Ok(user);
        }
        [HttpDelete("Delete User")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _registerService.GetUserIdAsync(id);
            if (user == null)
                return BadRequest("No user by id");
            _registerService.DeleteUser(id);
            return Ok("User Deleted");
        }
       
    }
}
