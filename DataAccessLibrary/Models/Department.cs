using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
