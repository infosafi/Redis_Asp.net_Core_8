using Microsoft.EntityFrameworkCore;
using Redis_Asp.net_Core_8.DataContext;
using Redis_Asp.net_Core_8.Models.Employee;
using Redis_Asp.net_Core_8.Repositories;

namespace Redis_Asp.net_Core_8.Services
{
    public class EmployeeService(ApplicationDBContext dBContext) : IEmployee
    {
       
        public async Task AddEmployeeAsync(Employee Employee)
        {
            await dBContext.Employee.AddAsync(Employee);
            await dBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            return await dBContext.Employee.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await dBContext.Employee.FindAsync(id);
        }
    }
}
