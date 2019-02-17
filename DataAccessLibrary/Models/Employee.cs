using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(500)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Birth { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        
        public Department Department { get; set; }
    }
}
