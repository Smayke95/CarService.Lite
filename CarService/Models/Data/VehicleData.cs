using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Models.Data
{
    public static class VehicleData
    {
        public static void GenerateData(this EntityTypeBuilder<Vehicle> entity)
        {
            entity.HasData(
                new Vehicle
                {
                    Id = 1,
                    Brand = "Opel",
                    Model = "Astra G",
                    OwnerId = 1,
                    LicencePlate = "J58-T-617",
                    ChassisNumber = "",
                    Engine = "2.0",
                    EngineNumber = "Z20LET"
                },
                new Vehicle
                {
                    Id = 2,
                    Brand = "Opel",
                    Model = "Corsa C",
                    OwnerId = 1,
                    LicencePlate = "E57-T-363",
                    ChassisNumber = "W0L0XCF0856049584",
                    Engine = "1.3",
                    EngineNumber = "Z13DT"
                }
            );
        }
    }
}