using System;
using Microsoft.EntityFrameworkCore;
using owasp_orminjection.Domain.Entities;
using owasp_orminjection.Domain.Interfaces;

namespace owasp_orminjection.Infrastructure.Repositories
{
    public class UnsecureCustomerRepository : ICustomerRepository
    {
        private IDBLoanManagerContext dBLoanManagerContext;

        public UnsecureCustomerRepository(IDBLoanManagerContext dBLoanManagerContext)
        {
            this.dBLoanManagerContext = dBLoanManagerContext;
        }

        public int Create(Customer t)
        {
            dBLoanManagerContext.Customers.Add(t);
            return dBLoanManagerContext.SaveChanges();
        }

        public bool Delete(Customer t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> FindAll()
        {
            return dBLoanManagerContext.Customers.ToList();
        }

        public IEnumerable<Customer> FindByLastname(string lastname)
        {
            return dBLoanManagerContext.Customers.FromSqlRaw($"Select * from Customer where Lastnames = '{lastname}'").ToList();
        }

        public IEnumerable<Customer> FindByName(string name)
        {
            return dBLoanManagerContext.Customers.FromSqlRaw($"Select * from Customer where Names = '{name}'").ToList();
        }

        public int Update(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}

