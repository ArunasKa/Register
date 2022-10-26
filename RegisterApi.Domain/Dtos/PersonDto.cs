using Microsoft.AspNetCore.Http;
using RegisterApi.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.Domain.Dtos
{
    public class PersonDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PersonalCode { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtentions(new[] { ".png", ".jpg" })]
        public IFormFile Image { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
