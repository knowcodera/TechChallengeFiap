using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.Property(c => c.Value)
                   .HasColumnName("CPF")
                   .IsRequired()
                   .HasMaxLength(11);
            });

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
