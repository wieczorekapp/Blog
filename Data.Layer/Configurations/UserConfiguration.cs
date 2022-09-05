using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasIndex(x => x.Login)
                .IsUnique();

            // one to one relation
            builder
                .HasOne(x => x.ContactInfo)
                .WithOne(x => x.User)
                .HasForeignKey<ContactInfo>(x => x.UserId);
        }
    }
}
