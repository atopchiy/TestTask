using System.Collections.Generic;


namespace BL.Interfaces
{
    public interface IService<T>
    {
        List<T> GetList(string search);
        T GetById(int id);
        bool Delete(int id);
        bool Edit(T subj);
        bool Add(T subj);
    }
}
