using CustomerAPI.DAL.Repositories;
using CustomerAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IGenericRepository<CustomerDTO> _repository;

        public CustomerController(IGenericRepository<CustomerDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            var customers = await _repository.GetAll();
            return customers;
        }

        [HttpGet("{id}")]

        public async Task<CustomerDTO> GetCustomer(long id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]

        public async Task<bool> DeleteCustomer()
        {
            throw new NotImplementedException();
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

        public async Task<bool> UpdateCustomer(CustomerDTO customerUpdate)
        {
            throw new NotImplementedException();
        }
    }

}
