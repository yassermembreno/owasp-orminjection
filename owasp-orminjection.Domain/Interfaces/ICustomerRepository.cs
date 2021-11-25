using System;
using owasp_orminjection.Domain.Entities;

namespace owasp_orminjection.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> FindByLastname(string lastname);
        IEnumerable<Customer> FindByName(string name);
    }
}

