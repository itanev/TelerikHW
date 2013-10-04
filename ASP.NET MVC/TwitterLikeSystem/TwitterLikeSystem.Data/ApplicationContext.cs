using TwitterLikeSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLikeSystem.Data
{
    public class ApplicationContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        // Db sets of tables.
        public DbSet<Tweet> Tweets { get; set; }

        //public System.Data.Entity.DbSet<TweetsViewModel> TweetsViewModel { get; set; }
    }
}
