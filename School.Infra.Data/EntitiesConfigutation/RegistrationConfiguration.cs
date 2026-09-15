using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Infra.Data.EntitiesConfigutation
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.UserId)
                .IsRequired();
            builder.Property(r => r.ClassId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Registrations)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Class)
               .WithMany(x => x.Registrations)
               .HasForeignKey(x => x.ClassId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
