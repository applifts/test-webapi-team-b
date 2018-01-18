using Microsoft.EntityFrameworkCore;
using TestWebApi.Domain.Entities;

namespace TestWebApi.Domain
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base((DbContextOptions) options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}