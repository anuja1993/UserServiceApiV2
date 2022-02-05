using Microsoft.EntityFrameworkCore;
using UserServiceApiV2.Entities;

namespace UserServiceApiV2.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person>? Persons { get; set; }

        public DbSet<User>? Users { get; set; }

        public DbSet<Admin>? Admins { get; set; }

        public DbSet<UserGroup>? UserGroups { get; set; }

        public DbSet<AccessRule>? AccessRules { get; set; }
    }
}
