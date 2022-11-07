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

        public async Task UpdatePersonAsync(int id, Person newUser)
        {
            _repository.UpdatePerson(newUser);
            await _repository.SaveChangesAsync();
        }
    }
}
