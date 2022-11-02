using System;

namespace CarService.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now.Date;

        public int Mileage { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}