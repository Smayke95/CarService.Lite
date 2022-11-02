using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models
{
    [Table("Services")]
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle? Vehicle { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int Mileage { get; set; }

        public string? Description { get; set; }
    }
}