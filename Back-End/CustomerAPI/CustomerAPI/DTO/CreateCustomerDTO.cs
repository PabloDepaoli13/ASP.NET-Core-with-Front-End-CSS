using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.DTO
{
    public class CreateCustomerDTO
    {
        [Required(ErrorMessage = "Este espacio es obligatorio")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Este espacio es obligatorio")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Este espacio es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este espacio es obligatorio")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Este espacio es obligatorio")]
        public string Address { get; set; }

    }
}
