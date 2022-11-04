using RegisterApi.BL.Interfaces;
using RegisterApi.DAL.Interfaces;
using RegisterApi.Domain.Dtos;
using RegisterApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.BL.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IDbRepository _repository;

        public RegisterService(IDbRepository dbRepository)
        {
            _repository = dbRepository;
        }

        public async  Task<Person?> GetPersonByIdAsync(int id)
        {
            return await _repository.GetPersonByIdAsync(id);
        }

        public async Task<HttpResponseMessage> UpdatePersonAsync(int id, Person newUser)
        {
           

            var userToUpdate = await _repository.GetPersonByIdAsync(id);
            if (userToUpdate == null)
                throw new ArgumentException("No user with such id");

            userToUpdate = newUser;
            _repository.UpdatePerson(userToUpdate);
            await _repository.SaveChangesAsync();
            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}
