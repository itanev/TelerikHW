﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Posts.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public Category()
        {
            this.Posts = new List<Post>();
        }
    }
}
