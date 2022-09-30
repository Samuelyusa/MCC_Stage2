using DTCMCC_WebApp_Sam.Models;
using Microsoft.EntityFrameworkCore;

namespace DTCMCC_WebApp_Sam.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base (dbContext)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Jobs> Jobs  { get; set; }
        public DbSet<Cuti> Cuti { get; set; }
        public DbSet<Staff> Staff { get; set; }

    }
}
