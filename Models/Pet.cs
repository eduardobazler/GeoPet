using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoPet.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Size { get; set; }
        public BreedEnum Breed { get; set; }
        [ForeignKey("FK_UserId")]
        public int FK_UserId { get; set; }
        public User User { get; set; }
    }
}