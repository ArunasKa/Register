using RegisterApi.BL.Interfaces;
using RegisterApi.DAL.Interfaces;
using RegisterApi.Domain.Dtos;
using RegisterApi.Domain.Helper;
using RegisterApi.Domain.Models;
using System.Drawing;

namespace RegisterApi.BL.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IDbRepository _repository;

        public RegisterService(IDbRepository dbRepository)
        {
            _repository = dbRepository;
        }

        public   void DeleteUser(int id)
        {
              _repository.DeleteUser(id);
              _repository.SaveChanges();
           
        }

        public async  Task<Person?> GetPersonByIdAsync(int id)
        {
            return await _repository.GetPersonByIdAsync(id);
        }
        public async  Task<UserAccount?> GetUserIdAsync(int id)
        {
            return await _repository.GetUserByIdAsync(id);
        }


        public async Task UpdateApartmentNumberAsync(int id, string apartmentNumber)
        {
            var person = await _repository.GetPersonByIdAsync(id);
            person.HomeAddress.ApartmentNumber = apartmentNumber;
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateCityAsync(int id, string city)
        {
            var person = await _repository.GetPersonByIdAsync(id);
            person.HomeAddress.City = city;
            await _repository.SaveChangesAsync();
        }

        public async  Task UpdateEmailAsync(int id, string email)
        {
            var person = await _repository.GetPersonByIdAsync(id);
            person.Email = email;
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateHouseNumberAsync(int id, string houseNumber)
        {
            var person = await _repository.GetPersonByIdAsync(id);
            person.HomeAddress.HouseNumber = houseNumber;
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateLastNameAsync(int id, string lastName)
        {
            var person = await _repository.GetPersonByIdAsync(id);
            person.LastName = lastName;
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateNameAsync(int id, string name)
        {
            var person = await _repository.GetPersonByIdAsync(id);
            person.Name = name;
            await _repository.SaveChangesAsync();
        }

        public async Task UpdatePersonalCodeAsync(int id, string personalCode)
        {
            var person = await _repository.GetPersonByIdAsync(id);
            person.PersonalCode = personalCode;
            await _repository.SaveChangesAsync();
        }

        

        public async Task UpdatePhoneNumberAsync(int id, string phoneNumber)
        {
            var person = await _repository.GetPersonByIdAsync(id);
            person.PhoneNumber = phoneNumber;
            await _repository.SaveChangesAsync();
        }

        public async  Task UpdatePhotoAsync(int id, ImageDto image)
        {
            var userToUpdate = await _repository.GetPersonByIdAsync(id);
            var resized = ImageEdit.ImageResize(image);

            userToUpdate.ImageBytes = resized;
            userToUpdate.ImageFileName = image.Image.FileName;
            userToUpdate.ImageContentType = image.Image.ContentType;

            await _repository.SaveChangesAsync();
        }

        public async Task UpdateStreetNameAsync(int id, string streetName)
        {
            var person = await _repository.GetPersonByIdAsync(id);
            person.HomeAddress.StreetName = streetName;
            await _repository.SaveChangesAsync();
        }

        

        public async Task UpdateUsernameAsync(int id, string username)
        {
            var user = await _repository.GetUserByIdAsync(id );
            user.UserName = username;
            await _repository.SaveChangesAsync();
        }
    }
}
