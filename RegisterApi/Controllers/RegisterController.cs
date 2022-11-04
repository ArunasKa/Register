using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterApi.BL.Interfaces;
using RegisterApi.Domain.Dtos;
using RegisterApi.Domain.Models;

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
        //public string ApartmentNumber { get; set; }
        [HttpPost("Update username")]
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


            using var memoryStream = new MemoryStream();
            image.Image.CopyTo(memoryStream);
            var imageByte = memoryStream.ToArray();

            userToUpdate.ProfilePicture.ImageBytes = imageByte;
            userToUpdate.ProfilePicture.FileName = image.Image.FileName;
            userToUpdate.ProfilePicture.ContentType = image.Image.ContentType;

            await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok();
        }
        //[HttpPost("Update City")]
        //public async Task<ActionResult> UpdateCity(int id, string name)
        //{
        //    //var success = await _registerService.UpdateUserName(name);
        //    return Ok();
        //}
        //[HttpPost("Update StreetName")]
        //public async Task<ActionResult> UpdateStreetName(int id, string name)
        //{
        //    //var success = await _registerService.UpdateUserName(name);
        //    return Ok();
        //}
        //[HttpPost("Update HouseNumber")]
        //public async Task<ActionResult> UpdateHouseNumber(int id, string name)
        //{
        //    //var success = await _registerService.UpdateUserName(name);
        //    return Ok();
        //}
        //[HttpPost("Update ApartmentNumber")]
        //public async Task<ActionResult> UpdateApartmentNumber(int id, string name)
        //{
        //    //var success = await _registerService.UpdateUserName(name);
        //    return Ok();
        //}

    }
}
