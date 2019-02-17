using System.Collections.Generic;
using DataAccessLibrary;
using DataAccessLibrary.Repositories;
using BL.Interfaces;
using DataAccessLibrary.Models;
using DataAccessLibrary.Interfaces;
using System.Linq;

namespace BL.Services
{
    public class EmployeeService : IService<Employee>
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool Add(Employee subj)
        {
            return _employeeRepository.Add(subj);
        }

        public bool Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }

        public bool Edit(Employee subj)
        {
            return _employeeRepository.Edit(subj);
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public List<Employee> GetList(string search)
        {
            if (search == null)
                search = "";
            return _employeeRepository.GetList().Where(emp =>
            emp.Name.ToLower().Contains(search.ToLower())
            || emp.Email.ToLower().Contains(search.ToLower()) || emp.Salary.ToString().Contains(search)
            || emp.Birth.ToString().Contains(search)).ToList();
        }
    }
}
