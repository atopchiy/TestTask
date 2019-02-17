using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly TestCrudContext _context;
        public DepartmentRepository(TestCrudContext context)
        {
            _context = context;
        }

        public List<Department> GetList()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Single(dep => dep.Id == id);
        }

        public bool Delete(int id)
        {
            var department = _context.Departments.Single(dep => dep.Id == id);
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return true;
        }

        public bool Edit(Department subj)
        {
            var department = new Department();
            if (!_context.Departments.Any(t => t.Name == subj.Name && t.Id != subj.Id))
            {
                department = _context.Departments.Single(dep => dep.Id == subj.Id);
                department.Name = subj.Name;
                department.Employees = subj.Employees;
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool Add(Department subj)
        {
            if (!_context.Departments.Any(t => t.Name == subj.Name))
            {
                _context.Departments.Add(subj);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
