using LarTechAPi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarTechAPi.Infrastructure.EntitiesConfiguration
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PhoneType)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasOne(p => p.Person)
                .WithMany(p => p.Phones)
                .HasForeignKey(p => p.PersonId);

            builder.HasData(
                new Phone(1, "Celular", "11999999999") { PersonId = 1 },
                new Phone(2, "Celular", "11999999998") { PersonId = 2 },
                new Phone(3, "Celular", "11999999997") { PersonId = 3 },
                new Phone(4, "Celular", "11999999996") { PersonId = 4 },
                new Phone(5, "Celular", "11999999995") { PersonId = 4 },
                new Phone(6, "Celular", "11999999994") { PersonId = 4 },
                new Phone(7, "Celular", "11999999993") { PersonId = 5 },
                new Phone(8, "Celular", "11999999992") { PersonId = 5 },
                new Phone(9, "Celular", "11999999991") { PersonId = 1 },
                new Phone(10, "Celular", "11999999990") { PersonId = 1 });
        }
    }
}
