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
            string sql = @$"Select
                                  *
                              From Customer
                             Where CustomerId = {id}";
            return dBLoanManagerContext.Customers.FromSqlRaw(sql)?.FirstOrDefault();
        }

        public IEnumerable<Customer> FindByLastname(string lastname)
        {
            string sql = @$"Select
                                  *
                              From Customer
                             Where Lastnames = '{lastname}'";
            return dBLoanManagerContext.Customers.FromSqlRaw(sql).ToList();
        }

        public IEnumerable<Customer> FindByName(string name)
        {
            string sql = @$"Select
                                  *
                              From Customer
                             Where Names = '{name}'";
            return dBLoanManagerContext.Customers.FromSqlRaw(sql).ToList();
        }

        public int Update(Customer t)
        {
            dBLoanManagerContext.Customers.Update(t);
            return dBLoanManagerContext.SaveChanges();
        }
    }
}

