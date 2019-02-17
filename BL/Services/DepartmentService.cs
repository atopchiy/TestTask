using System;
using System.Collections.Generic;
using System.Linq;
using BL.Interfaces;
using DataAccessLibrary;
using DataAccessLibrary.Repositories;
using DataAccessLibrary.Interfaces;

namespace BL.Services
{
    public class DepartmentService : IService<Department>
    {
        private readonly IRepository<Department> _departmentRepository;
        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public bool Add(Department subj)
        {
           return _departmentRepository.Add(subj);
        }

        public bool Delete(int id)
        {
            return _departmentRepository.Delete(id);
        }

        public bool Edit(Department subj)
        {
            return _departmentRepository.Edit(subj);
        }

        public Department GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public List<Department> GetList(string search)
        {
            if (search == null)
                search = "";
            return _departmentRepository.GetList().Where(d => d.Name.ToLower().Contains(search.ToLower())).ToList();
        }
    }
}
