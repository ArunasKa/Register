using System.ComponentModel.DataAnnotations;

namespace RegisterApi.Domain.Models
{
    public   class Address
    {
        public int Id { get; set; }
        [MaxLength(250), Required]
        public string City { get; set; }
        [MaxLength(250), Required]
        public string StreetName { get; set; }
        [MaxLength(250), Required]
        public string HouseNumber { get; set; }
        [MaxLength(250), Required]
        public string ApartmentNumber { get; set; }
    }
}
