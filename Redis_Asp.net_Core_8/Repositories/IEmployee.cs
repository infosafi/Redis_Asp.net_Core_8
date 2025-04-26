using Redis_Asp.net_Core_8.Models.Employee;

namespace Redis_Asp.net_Core_8.Repositories
{
    public interface IEmployee
    {

        Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee product);
    }
}
