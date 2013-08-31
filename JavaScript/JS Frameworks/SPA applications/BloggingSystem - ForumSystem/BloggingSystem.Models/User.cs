using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string AuthCode { get; set; }
        public string SessionKey { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public User()
        {
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
        }
    }
}
