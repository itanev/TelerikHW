using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /// <summary>
    /// Just a regular object.
    /// </summary>
    public class EnemyTank : EnemyAttacker
    {
        private Random generator = new Random();

        public void FireWeapon()
        {
            int attackDamage = this.generator.Next(10) + 1;
            Console.WriteLine("Enemy Tank Does {0} Damage.", attackDamage);
        }

        public void DriveForward()
        {
            int movement = this.generator.Next(5) + 1;
            Console.WriteLine("Enemy Tank moves {0} spaces.", movement);
        }

        public void AssignDriver(String driverName) 
        {
            Console.WriteLine("{0} is driving the tank", driverName);
	    }
    }
}
