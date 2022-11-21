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
        [MaxLength(250), Required]
        public string PersonalCode { get; set; }
        [MaxLength(250), Required]
        public string PhoneNumber { get; set; }
        [MaxLength(500), Required]
        public string Email { get; set; }
        [Required]
        public byte[] ImageBytes { get; set; }
        [MaxLength(250), Required]
        public string ImageFileName { get; set; }
        [MaxLength(250), Required]
        public string ImageContentType { get; set; }
        public Address HomeAddress { get; set; }
    }
}
