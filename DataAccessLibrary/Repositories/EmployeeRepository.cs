using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly TestCrudContext _context;
        public EmployeeRepository(TestCrudContext context)
        {
            _context = context;
        }

        public List<Employee> GetList()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Single(emp => emp.Id == id);
        }

        public bool Delete(int id)
        {
            var employee = _context.Employees.Single(emp => emp.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return true;
        }

        public bool Edit(Employee subj)
        {
            var employee = new Employee();
            if (!_context.Employees.Any(t => t.Email == subj.Email && t.Id != subj.Id))
            {
                employee = _context.Employees.Single(emp => emp.Id == subj.Id);
                employee.Name = subj.Name;
                employee.Birth = subj.Birth;
                employee.DepartmentId = subj.DepartmentId;
                employee.Email = subj.Email;
                employee.Salary = subj.Salary;
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool Add(Employee subj)
        {
            if (!_context.Employees.Any(t => t.Email == subj.Email))
            {
                _context.Employees.Add(subj);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
