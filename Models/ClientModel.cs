using System.ComponentModel.DataAnnotations;

namespace practica.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Cedula_RUC { get; set; }  
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


        //Propiedad opcional
        public int? Age { get; set; } = null;
        public bool Gender { get; set; } = false;
        public DateOnly DateOfBirth { get; set; }
    }
}
