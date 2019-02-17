using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCRUD.Models
{
    public class DepartmentViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Department's name is required")]
        public string Name { get; set; }
    }
}
