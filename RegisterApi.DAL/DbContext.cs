using Microsoft.EntityFrameworkCore;
using RegisterApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.DAL
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<UserAccount> UserInformation { get; set; }
        public DbSet<Person> PersonInformation { get; set; }
        public DbSet<Address> AdrressInformation { get; set; }
        public DbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
