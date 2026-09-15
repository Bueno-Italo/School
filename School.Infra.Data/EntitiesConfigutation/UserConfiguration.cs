using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infra.Data.EntitiesConfigutation
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(u => u.PasswordHash)
                .IsRequired();
            builder.Property(u => u.PasswordSalt)
               .IsRequired();
            builder.Property(u => u.Profile)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
