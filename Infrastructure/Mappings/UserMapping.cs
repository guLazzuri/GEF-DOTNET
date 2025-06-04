using Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Gef_User");

            builder.HasKey(u => u.UserID);

            builder
                .Property(u => u.UserID)
                .ValueGeneratedOnAdd();

            builder
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.Age)
                .IsRequired();

            builder
                .Property(u => u.Gender)
                .HasConversion<string>() // <-- Aqui
                .IsRequired();

            builder
                .Property(u => u.BloodType)
                .HasConversion<string>() // <-- Aqui
                .IsRequired();

            builder
                .Property(u => u.Weight)
                .IsRequired();

            builder
                .Property(u => u.ResponsableName)
                .HasMaxLength(100);

            builder
                .Property(u => u.CPF)
                .HasMaxLength(11);

            builder
                .Property(u => u.CardNumber)
                .HasMaxLength(20);

            builder
                .Property(u => u.UserType)
                .HasConversion<string>() // <-- Aqui=
                .IsRequired();


            builder
                .Property(u => u.ShelterID)
                .IsRequired();


        }
    }
}
