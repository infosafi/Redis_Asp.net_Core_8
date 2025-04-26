using Microsoft.EntityFrameworkCore;
using Redis_Asp.net_Core_8.Models.Employee;

namespace Redis_Asp.net_Core_8.DataContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options):base (options) {

        }
        public DbSet<Employee> Employee { get; set; }

    }
}
