using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models
{
    [Table("Models")]
    public class Model
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
    }
}