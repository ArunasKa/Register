using Microsoft.EntityFrameworkCore;
using RegisterApi.Domain.Models;

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
