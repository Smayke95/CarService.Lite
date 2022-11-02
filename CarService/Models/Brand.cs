using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models
{
    [Table("Brands")]
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;



        // Relations
        public virtual ICollection<Model>? Models { get; set; }
    }
}