using CustomerAPI.DAL.Repositories;
using CustomerAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGenericRepository<CustomerDTO> _repository;

        public CustomerController(IGenericRepository<CustomerDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customers = await _repository.GetAll();
            if (customers == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new {customers});
            }

            //Creating a message from Serilog
            Log.Information("This is a new message from logging, your object => {@customers}", customers);

            return StatusCode(StatusCodes.Status200OK, new { customers });
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customers = await _repository.GetById(id);
            if (customers == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { customers });
            }
            return StatusCode(StatusCodes.Status200OK, new { customers });
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            var customers = await _repository.GetById(id);
            if (customers == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { customers });
            }
            bool result = await _repository.DeleteById(id);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { result });
            }
            return StatusCode(StatusCodes.Status200OK, new { result });
        }

        [HttpPost]

        public async Task<IActionResult> CreateCustomer(CreateCustomerDTO customerNew)
        {
            var customer = new CustomerDTO
            {
                FirstName = customerNew.FirstName,
                LastName = customerNew.LastName,
                Address= customerNew.Address,
                Email= customerNew.Email,   
                Phone = customerNew.Phone
            };
            bool result = await _repository.CreateCustomer(customer);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "No se pudo cargar en el servidor"});
            }
            return StatusCode(StatusCodes.Status200OK, new {message = "Cargado con exito"});
        }

        [HttpPut]

        public async Task<ActionResult<bool>> UpdateCustomer(CustomerDTO customerUpdate)
        {
            bool result = await _repository.Update(customerUpdate);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { result });
            }
            return StatusCode(StatusCodes.Status200OK, new { result });
        }
    }

}
