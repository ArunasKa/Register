using RegisterApi.Domain.Dtos;
using RegisterApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.BL.Interfaces
{
    public interface IRegisterService
    {
        Task<HttpResponseMessage> UpdatePersonAsync(int id, Person newUser);
        Task<Person?> GetPersonByIdAsync(int id);
    }
}
