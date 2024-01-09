using LarTechAPi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarTechAPi.Infrastructure.EntitiesConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(p => p.Birthday)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.IsActive)
                .IsRequired()
                .HasColumnType("bit");

            builder.HasMany(p => p.Phones)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonId);

            builder.HasData(
                new Person(1, "João", "12345678901", new DateTime(1990, 01, 01), true),
                new Person(2, "Maria", "12345678902", new DateTime(1990, 01, 01), true),
                new Person(3, "José", "12345678903", new DateTime(1990, 01, 01), true),
                new Person(4, "Pedro", "12345678904", new DateTime(1990, 01, 01), false),
                new Person(5, "Paulo", "12345678905", new DateTime(1990, 01, 01), false),
                new Person(6, "Lucas", "12345678906", new DateTime(1990, 01, 01), false),
                new Person(7, "Marcos", "12345678907", new DateTime(1990, 01, 01), false),
                new Person(8, "Mateus", "12345678908", new DateTime(1990, 01, 01), false),
                new Person(9, "Tiago", "12345678909", new DateTime(1990, 01, 01), false),
                new Person(10, "João", "12345678910", new DateTime(1990, 01, 01), true),
                new Person(11, "Maria", "12345678911", new DateTime(1990, 01, 01), true),
                new Person(12, "José", "12345678912", new DateTime(1990, 01, 01), false),
                new Person(13, "Pedro", "12345678913", new DateTime(1990, 01, 01), true),
                new Person(14, "Paulo", "12345678914", new DateTime(1990, 01, 01), false),
                new Person(15, "Lucas", "12345678915", new DateTime(1990, 01, 01), true),
                new Person(16, "Marcos", "12345678916", new DateTime(1990, 01, 01), false));
        }
    }
}
