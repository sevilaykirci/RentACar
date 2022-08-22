using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Concrete;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomersController (ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            var result = _customerService.GetAll();
            return result.Data;
        }
    }
}
