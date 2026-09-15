using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Infra.Data.EntitiesConfigutation
{
    public class NotaConfiguration : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.ValueNota)
                .IsRequired();
            builder.Property(r => r.RegistrationId)
                .IsRequired();

            builder.HasOne(x => x.Registration)
              .WithMany(x => x.Notas)
              .HasForeignKey(x => x.RegistrationId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
