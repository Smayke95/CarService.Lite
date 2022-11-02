using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CarService.Models.Data
{
    public static class ServiceData
    {
        public static void GenerateData(this EntityTypeBuilder<Service> entity)
        {
            entity.HasData(
                new Service
                {
                    Id = 1,
                    VehicleId = 1,
                    Date = DateTime.Now,
                    Mileage = 200000,
                    Description = "Veliki servis"
                },
                new Service
                {
                    Id = 2,
                    VehicleId = 1,
                    Date = DateTime.Now.AddHours(1),
                    Mileage = 210000,
                    Description = "Mali servis"
                }
            );
        }
    }
}