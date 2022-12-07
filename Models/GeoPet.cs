using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoPet.Models
{
    public class GeoPet
    {
        [Key]
        public int Id { get; set; }
        public string Localization { get; set; }
        [ForeignKey("PetId")]
        public int PetId { get; set; }
        public DateTime Created { get; set; }
    }
}