using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models
{
    [Table("Owners")]
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;



        // Relations
        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}