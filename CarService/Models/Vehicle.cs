using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public virtual Owner? Owner { get; set; }

        public string LicencePlate { get; set; } = string.Empty;

        public string? ChassisNumber { get; set; }

        public string? Engine { get; set; }

        public string? EngineNumber { get; set; }

        public string? Description { get; set; }



        // Relations
        public virtual ICollection<Service>? Services { get; set; }
    }
}