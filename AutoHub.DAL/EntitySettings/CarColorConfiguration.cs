using AutoHub.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoHub.DAL.EntitySettings
{
    public class CarColorConfiguration : IEntityTypeConfiguration<CarColor>
    {
        public void Configure(EntityTypeBuilder<CarColor> builder)
        {
            builder.ToTable(nameof(CarColor));

            builder.HasMany(color => color.Cars)
                .WithOne(car => car.CarColor)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}