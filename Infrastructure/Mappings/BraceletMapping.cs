using Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class BraceletMapping : IEntityTypeConfiguration<Bracelet>
    {
        public void Configure(EntityTypeBuilder<Bracelet> builder)
        {
            builder.ToTable("Gef_Bracelets");

            builder.HasKey(b => b.BraceletID);

            builder
                .Property(b => b.BraceletID)
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.UserId)
                .IsRequired();

            builder
                .Property(b => b.LastBPM);

            builder
                .Property(b => b.LastUpdate)
                .IsRequired();

            builder
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Bracelet>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
