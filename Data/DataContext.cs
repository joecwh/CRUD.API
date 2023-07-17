using CRUD.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
