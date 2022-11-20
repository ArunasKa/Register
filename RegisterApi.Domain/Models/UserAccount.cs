using System.ComponentModel.DataAnnotations;

namespace RegisterApi.Domain.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        [MaxLength(250), Required]
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [MaxLength(250), Required]
        public string Role { get; set; }
        public Person Person { get; set; }

        //zmogaus informaciojos sarysis (asmens kodas?)

    }
}
