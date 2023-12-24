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

        public async Task<bool> CreateCustomer(CreateCustomerDTO customerNew)
        {
            throw new NotImplementedException();
        }

        [HttpPut]

        public async Task<bool> UpdateCustomer(CustomerDTO customerUpdate)
        {
            throw new NotImplementedException();
        }
    }

}
