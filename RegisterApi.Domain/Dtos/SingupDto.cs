using RegisterApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.Domain.Dtos
{
    public class SingupDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public PersonDto PersonDto { get; set; }
    }
}
