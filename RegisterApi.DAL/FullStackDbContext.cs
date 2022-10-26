using Microsoft.EntityFrameworkCore;
using RegisterApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.DAL
{
    public class FullStackDbContext : DbContext
    {
        public DbSet<UserAccount> UserInformation { get; set; }
        public DbSet<Person> PersonInformation { get; set; }
        public DbSet<Address> AdrressInformation { get; set; }
        public FullStackDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
