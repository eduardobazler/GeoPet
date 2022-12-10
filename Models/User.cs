using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoPet.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Password { get; set; }
        [InverseProperty("User")]
        public ICollection<Pet> Pets { get; set; }
        public DateTime Created { get; set; }
    }
}