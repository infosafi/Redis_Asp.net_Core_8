using System.ComponentModel.DataAnnotations.Schema;

namespace Redis_Asp.net_Core_8.Models.Employee
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set;}
        public string Name { get; set; }            
        public string Email { get; set; }
        public string Address { get; set; }=String.empty;
        public string Phone { get; set; }
    }
}
