using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.Models.Data
{
    public static class OwnerData
    {
        public static void GenerateData(this EntityTypeBuilder<Owner> entity)
        {
            entity.HasData(
                new Owner
                {
                    Id = 1,
                    FirstName = "Anes",
                    LastName = "Smajić",
                    Phone = "62 715 825"
                }
            );
        }
    }
}