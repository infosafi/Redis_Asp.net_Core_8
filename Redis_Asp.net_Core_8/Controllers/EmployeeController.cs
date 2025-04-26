using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redis_Asp.net_Core_8.Models.Employee;
using Redis_Asp.net_Core_8.Repositories;

namespace Redis_Asp.net_Core_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployee employee, IRedisCache _cache) : ControllerBase
    {



        [HttpGet("get-employee")]
        public async Task<ActionResult> GetAllEmployee()
        {
            try
            {
                var empployeelist_cache = _cache.GetData<IEnumerable<Employee>>("employee");
                if(empployeelist_cache is not null)
                {
                    return  Ok(empployeelist_cache);
                }
                 empployeelist_cache = await employee.GetAllEmployeeAsync();
                _cache.SetData("employee", empployeelist_cache);
                return Ok(empployeelist_cache);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-employee")]
        public async Task<IActionResult> CreateEmployee(int Empid, string empname, string email,
            string address, string phone)
        {
            try
            {
                Employee emp= new Employee();
                emp.EmployeeId = Empid;
                emp.Name = empname;
                emp.Email = email;
                emp.Address = address;
                emp.Phone = phone;
                await employee.AddEmployeeAsync(emp);
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-single-employee{id}")]
        public async Task<ActionResult> GetSingleEmployeeByid(int id)
        {
            try
            {
               
                var singleemp = await employee.GetEmployeeByIdAsync(id);                
                return Ok(singleemp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    
}
