using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetList();
        T GetById(int id);
        bool Delete(int id);
        bool Edit(T subj);
        bool Add(T subj);
    }
}
