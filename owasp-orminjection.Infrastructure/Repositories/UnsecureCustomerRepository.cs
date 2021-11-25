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
            dBLoanManagerContext.Customers.Remove(t);           
            return dBLoanManagerContext.SaveChanges() > 0;
        }

        public IEnumerable<Customer> FindAll()
        {
            return dBLoanManagerContext.Customers.ToList();
        }

        public Customer FindById(int id)
        {
            return dBLoanManagerContext.Customers.Where(c => c.CustomerId == id)?.FirstOrDefault();
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
            dBLoanManagerContext.Customers.Update(t);
            return dBLoanManagerContext.SaveChanges();
        }
    }
}

