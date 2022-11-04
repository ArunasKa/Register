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

            var success = await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok(success);
        }


        [HttpPost("Update lastname")]
        public async Task<ActionResult> UpdateLastName(int id, string lastName)
        {
            var userToUpdate = await _registerService.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                return BadRequest("No user by id");
            userToUpdate.LastName = lastName;

            var success = await _registerService.UpdatePersonAsync(id, userToUpdate);
            return Ok(success);
        }
        //[HttpPost("Update PersonalCode")]
        //public async Task<ActionResult> UpdatePersonalCode(int id, string name)
        //{
        //    //var success = await _registerService.UpdateUserName(name);
        //    return Ok();
        //}
        //[HttpPost("Update Email")]
        //public async Task<ActionResult> UpdateEmail(int id, string name)
        //{
        //    //var success = await _registerService.UpdateUserName(name);
        //    return Ok();
        //}
        //[HttpPost("Update Photo")]
        //public async Task<ActionResult> UpdatePhoto(int id, string name)
        //{
        //    //var success = await _registerService.UpdateUserName(name);
        //    return Ok();
        //}
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
