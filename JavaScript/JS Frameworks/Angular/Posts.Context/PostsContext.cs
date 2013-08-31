using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Posts.Models;

namespace Posts.Context
{
    public class PostsContext : DbContext
    {
        public PostsContext() : 
            base("PostsDb")
        { 
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
