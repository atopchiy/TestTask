using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCRUD.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Employee's name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Employee's birthdate is required")]
        public DateTime Birth { get; set; }
        [Required(ErrorMessage ="Employee's email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Employee's salary is required")]
        public int Salary { get; set; }
        [Required(ErrorMessage ="Employee must be associated with department")]
        public int DepartmentId { get; set; }
    }
}
