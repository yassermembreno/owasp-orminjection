using System;
namespace owasp_orminjection.Application.Interfaces
{
    public interface IService<T>
    {
        int Create(T t);
        int Update(T t);
        bool Delete(T t);
        IEnumerable<T> FindAll();
    }
}

