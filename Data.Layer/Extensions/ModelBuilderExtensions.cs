using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Extensions
{
    static class ModelBuilderExtensions
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "General",
                Description = "All general posts",
                Url = "general"
            }
            );
        }
    }
}
