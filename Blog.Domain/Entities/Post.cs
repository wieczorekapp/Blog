using Blog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }

        // wykorzystanie data annotations
        //[Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public bool Published { get; set; }
        public DateTime PostOn { get; set; }
        public DateTime? Modified { get; set; }
        public PostType Type { get; set; }

        public int UserId { get; set; }
        public User User  { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}
