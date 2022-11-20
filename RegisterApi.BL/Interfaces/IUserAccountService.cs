using RegisterApi.Domain.Dtos;

namespace RegisterApi.BL.Interfaces
{
    public interface IUserAccountsService
    {
        Task<bool> CreateUserAccountAsync(SingupDto signupDto);
        Task<(bool authenticationsuccessful, string? role)> LogInAsync(string userName, string pasword);
    }
}
