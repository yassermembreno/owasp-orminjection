using System;
namespace owasp_orminjection.Application.Interfaces
{
    public interface IService<T>
    {
        int Create(T t);
        int Update(T t);
        bool Delete(int id);
        IEnumerable<T> FindAll();
    }
}

