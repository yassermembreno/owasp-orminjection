using System;
using owasp_orminjection.Domain.Entities;

namespace owasp_orminjection.Application.Interfaces
{
    public interface ICustomerService : IService<Customer>
    {
        Customer FindById(int id);
        IEnumerable<Customer> FindByLastname(string lastname);
        IEnumerable<Customer> FindByName(string name);
    }
}

