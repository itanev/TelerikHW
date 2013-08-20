using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggingSystem.Services.Models
{
    public class TagsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumPosts { get; set; }
    }
}