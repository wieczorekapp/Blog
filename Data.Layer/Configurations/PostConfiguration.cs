﻿using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Configurations
{
    class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //builder.ToTable("Posts2");

            // wykorzystanie FluentApi
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);
            //.HasColumnName("Title2");

            builder.Property(x => x.PostOn)
                .HasColumnType("datetime");

            builder.Property(x => x.ShortDescription)
                .HasMaxLength(200);

            builder.Property(x => x.ImageUrl)
                .IsUnicode(false)
                .HasMaxLength(250)
                .HasDefaultValue("/content/image.png");

            builder.Property(x => x.Published)
                .IsRequired(false);

        }
    }
}
    