﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.Domain.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public Person Person { get; set; }

        //zmogaus informaciojos sarysis (asmens kodas?)

    }
}