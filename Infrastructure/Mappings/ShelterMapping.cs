using Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class ShelterMapping : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            builder.ToTable("Gef_Shelters");

            builder.HasKey(s => s.ShelterID);

            builder
                .Property(s => s.ShelterID)
                .ValueGeneratedOnAdd();

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(s => s.Quantity)
                .IsRequired();

            builder
                .Property(s => s.Capacity)
                .IsRequired();

            // Relacionamento 1:N com User
            builder
                .HasMany(s => s.Users)
                .WithOne()
                .HasForeignKey(u => u.ShelterID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
