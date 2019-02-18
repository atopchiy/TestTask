using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL.Interfaces;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCRUD.Models;

namespace TestCRUDWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<Employee> _employeeService;
        private readonly IMapper _mapper;
        // GET: /<controller>/
        public EmployeeController(IService<Employee> employeeService,
            IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost("{id}")]
        public PageViewModel<EmployeeViewModel> Get(int id, [FromBody]PageViewModel<Department> paging)
        {
            var employees = _employeeService.GetList(paging.Search).Where(emp => emp.DepartmentId == id).ToList();
            var paged = employees.Skip((paging.PageNumber - 1) * 5)
                                .Take(5)
                                .AsQueryable();
            return new PageViewModel<EmployeeViewModel>((int)Math.Ceiling((decimal)employees.Count / 5), paging.PageNumber,
               _mapper.ProjectTo<EmployeeViewModel>(paged).ToList(), paging.Search);
        }

        [HttpPost("add")]
        public bool AddEmployee(EmployeeViewModel employee)
        {
            return _employeeService.Add(_mapper.Map<Employee>(employee));
        }
)        [HttpDelete("{id}")]
        public bool DeleteEmployee(int id)
        {
            _employeeService.Delete(id);
            return true;
        }
        [HttpPut]
        public bool UpdateEmployee(EmployeeViewModel employee)
        {
            
            return _employeeService.Edit(_mapper.Map<Employee>(employee));
        }
    }
}