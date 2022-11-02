namespace CarService.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public OwnerViewModel Owner { get; set; } = new OwnerViewModel();

        public string LicencePlate { get; set; } = string.Empty;

        public string? ChassisNumber { get; set; }

        public string? Engine { get; set; }

        public string? EngineNumber { get; set; }

        public string? Description { get; set; }
    }
}