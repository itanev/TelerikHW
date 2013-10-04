using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLikeSystem.Models
{
    public class ApplicationUser : User
    {
        public ApplicationUser()
        {
            this.Tweets = new HashSet<Tweet>();
        }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}
