using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoPet.Models
{
    public class GeoLocalization
    {
        [Key]
        public int Id { get; set; }
        public string Localization { get; set; }
        public int OsmId { get; set; }
        [ForeignKey("FK_PetId")]
        public int PetId { get; set; }
        public DateTime Created { get; set; }
    }
}