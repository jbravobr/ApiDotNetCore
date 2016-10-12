using System;
using System.Linq;
using System.Threading.Tasks;
using ApiDotNetCore;
using ApiDotNetCore.Domain;
using Microsoft.AspNetCore.Mvc;

namespace APIDotNetCore.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        readonly IServiceBase<ApiDotNetCore.Domain.Customer> _customerService;

        public HomeController(IServiceBase<ApiDotNetCore.Domain.Customer> customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest("Customer precisa ser informado");

            try
            {
                _customerService.Insert(customer);
                var newCustomer = await _customerService.GetMostRecent();

                return CreatedAtRoute("GetCustomer", new { id = newCustomer._id }, newCustomer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest("Customer precisa ser informado");

            try
            {
                var customerItem = await _customerService.GetById(id);

                if (customerItem == null)
                    return NotFound("Customer não encontrado");

                var ret = await _customerService.Update(id, customer);

                if (ret)
                    return new NoContentResult();

                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("É preciso informar o ID da entidade quer será removida");

            var customer = await _customerService.GetById(id);

            if (customer == null)
                return NotFound();

            var ret = await _customerService.DeleteById(id);

            if (ret)
                return new NoContentResult();

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.GetAll();

                if (customers != null && customers.Any())
                    return new ObjectResult(customers);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomerById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var customer = await _customerService.GetById(id);

            if (customer == null)
                return NotFound();

            return new ObjectResult(customer);
        }
    }
}
