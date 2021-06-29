using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Models
{
    //[Table("emp_table")]
    public class Employee
    {
        public int Id { get; set; }
        //[Column("first_name")]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
