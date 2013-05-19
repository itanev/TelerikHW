using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /// <summary>
    /// This is the target.
    /// </summary>
    public interface EnemyAttacker
    {
        void FireWeapon();
        void DriveForward();
        void AssignDriver(String driverName);
    }
}
