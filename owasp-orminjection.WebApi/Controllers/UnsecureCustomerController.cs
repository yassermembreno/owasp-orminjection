using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using owasp_orminjection.Application.Interfaces;
using owasp_orminjection.Domain.Entities;
using owasp_orminjection.Domain.Interfaces;

namespace owasp_orminjection.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnsecureCustomerController : Controller
    {
        private ICustomerService customerService;

        public UnsecureCustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return customerService.FindAll();
        }

        [HttpGet]
        [Route("/lastname/{lastname}")]
        public IEnumerable<Customer> GetCustomers(string lastname)
        {
            return customerService.FindByLastname(lastname);
        }

        [HttpPost]
        public ActionResult<int> CreateCustomer(Customer customer)
        {
            int result = customerService.Create(customer);
            return result > 0 ? Ok(result) : BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            return customerService.Delete(id) ? Ok() : NotFound(); 
        }
    }
}

