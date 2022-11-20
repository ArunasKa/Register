using RegisterApi.Domain.Dtos;
using RegisterApi.Domain.Models;

namespace RegisterApi.BL.Interfaces
{
    public interface IRegisterService
    {
        Task<Person?> GetPersonByIdAsync(int id);
        Task<UserAccount?> GetUserIdAsync(int id);
        void DeleteUser(int id);
        Task UpdateUsernameAsync(int id, string username);
        Task UpdateNameAsync(int id, string name);
        Task UpdateLastNameAsync(int id, string lastName);
        Task UpdatePhoneNumberAsync(int id, int phoneNumber);
        Task UpdatePersonalCodeAsync(int id, int personalCode);
        Task UpdateEmailAsync(int id, string email);
        Task UpdatePhotoAsync(int id, ImageDto image);
        Task UpdateCityAsync(int id, string city);
        Task UpdateStreetNameAsync(int id, string streetName);
        Task UpdateHouseNumberAsync(int id, string houseNumber);
        Task UpdateApartmentNumberAsync(int id, string apartmentNumber);
    }
}
