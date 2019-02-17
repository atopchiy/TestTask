using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL.Interfaces;
using DataAccessLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCRUD.Models;

namespace TestCRUDWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IService<Department> _departmentService;
        private readonly IMapper _mapper;
        // GET: /<controller>/
        public DepartmentController(IService<Department> departmentService,
            IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
     
        [HttpPost]
        public PageViewModel<DepartmentViewModel> Get([FromBody]PageViewModel<Department> paging)
        {
            var departments = _departmentService.GetList(paging.Search);
            var paged = departments.Skip((paging.PageNumber - 1) * 5)
                                .Take(5)
                                .AsQueryable();
            return new PageViewModel<DepartmentViewModel>((int)Math.Ceiling((decimal)departments.Count / 5), paging.PageNumber,
               _mapper.ProjectTo<DepartmentViewModel>(paged).ToList(), paging.Search);
        }
               

        [HttpPost("add")]
        public bool AddDepartment(DepartmentViewModel department)
        {
            return _departmentService.Add(_mapper.Map<Department>(department));
        }
        [HttpDelete("{id}")]
        public bool DeleteDepartment(int id)
        {
            _departmentService.Delete(id);
            return true;
        }
        [HttpPut]
        public bool UpdateDepartment(DepartmentViewModel department)
        {
            return _departmentService.Edit(_mapper.Map<Department>(department)); ;
        }
    }
}