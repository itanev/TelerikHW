using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    /// <summary>
    /// This is the adapter.
    /// </summary>
    public class EnemyRobotAdapter : EnemyAttacker
    {
	    private EnemyRobot theRobot;
	
	    public EnemyRobotAdapter(EnemyRobot newRobot)
        {
		    this.theRobot = newRobot;
	    }
	
	    public void FireWeapon() 
        {
		    this.theRobot.SmashWithHands();
	    }

	    public void DriveForward() 
        {
		    this.theRobot.WalkForward();
	    }

	    public void AssignDriver(String driverName) 
        {
		    this.theRobot.ReactToHuman(driverName);
	    }
    }
}
