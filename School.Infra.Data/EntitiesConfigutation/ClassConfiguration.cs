using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;

namespace School.Infra.Data.EntitiesConfigutation
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(c => c.CourseId)
                .IsRequired();

            builder.HasOne(c => c.Course)
              .WithMany(c => c.Classes)
              .HasForeignKey(c => c.CourseId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
