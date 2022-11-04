using RegisterApi.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.BL.Interfaces
{
    public interface IUserAccountsService
    {
        Task<bool> CreateUserAccountAsync(SingupDto signupDto);
        Task<(bool authenticationsuccessful, string? role)> LogInAsync(string userName, string pasword);
    }
}
