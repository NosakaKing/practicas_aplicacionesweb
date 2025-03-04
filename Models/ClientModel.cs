using System.ComponentModel.DataAnnotations;

namespace practica.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        [Required]
        public string Cedula_RUC { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int RolId { get; set; }

        public RolModel? Rol { get; set; }

        public int? Age { get; set; }

        public bool Gender { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
