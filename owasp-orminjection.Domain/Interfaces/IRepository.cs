using System;
namespace owasp_orminjection.Domain.Interfaces
{
    public interface IRepository<T>
    {
        int Create(T t);
        int Update(T t);
        bool Delete(T t);
        IEnumerable<T> FindAll();
    }
}

