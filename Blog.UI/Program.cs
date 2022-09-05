using Blog.DataLayer;
using System;
using System.Linq;

namespace Blog.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                var post = context.Posts.FirstOrDefault();
                Console.WriteLine(post.Title);
            }

            Console.ReadLine();
        }
    }
}
