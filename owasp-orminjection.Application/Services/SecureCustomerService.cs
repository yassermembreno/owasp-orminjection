using System;
using owasp_orminjection.Application.Interfaces;
using owasp_orminjection.Domain.Entities;
using owasp_orminjection.Domain.Interfaces;

namespace owasp_orminjection.Application.Services
{
    public class SecureCustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository;
        public SecureCustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public int Create(Customer t)
        {
            return customerRepository.Create(t);
        }

        public bool Delete(int id)
        {
            Customer customer = FindById(id);
            if(customer == null)
            {
                return false;
            }
            return customerRepository.Delete(customer);
        }

        public IEnumerable<Customer> FindAll()
        {
            return customerRepository.FindAll();
        }

        public Customer FindById(int id)
        {
            return customerRepository.FindById(id);
        }

        public IEnumerable<Customer> FindByLastname(string lastname)
        {
            return customerRepository.FindByLastname(lastname);
        }

        public IEnumerable<Customer> FindByName(string name)
        {
            return customerRepository.FindByName(name);
        }

        public int Update(Customer t)
        {
            return customerRepository.Update(t);
        }
    }
}

