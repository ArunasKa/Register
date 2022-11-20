using System.ComponentModel.DataAnnotations;

namespace RegisterApi.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(250), Required]
        public string Name { get; set; }
        [MaxLength(250), Required]
        public string LastName { get; set; }
        [MaxLength(50), Required]
        public int PersonalCode { get; set; }
        [MaxLength(50), Required]
        public int PhoneNumber { get; set; }
        [MaxLength(500), Required]
        public string Email { get; set; }
        [MaxLength(500), Required]
        public byte[] ImageBytes { get; set; }
        [MaxLength(250), Required]
        public string ImageFileName { get; set; }
        [MaxLength(250), Required]
        public string ImageContentType { get; set; }
        public Address HomeAddress { get; set; }
    }
}
