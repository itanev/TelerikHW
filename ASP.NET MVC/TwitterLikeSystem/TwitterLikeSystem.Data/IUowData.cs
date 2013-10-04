using TwitterLikeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLikeSystem.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Tweet> Tweets { get; }
        
        // other repositories...

        int SaveChanges();
    }
}
