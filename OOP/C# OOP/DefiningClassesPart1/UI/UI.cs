using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileDevice;

namespace UI
{
    class UI
    {
        static void Main()
        {
            try
            {
                //initializing new gsm
                GSM MyGSM = new GSM("Monte", "Samsung", 10, "Pesho",
                    "DINO", 10, 6, BatteryType.LiIon, 7, 256000);

                //setting static field value
                GSM.IPhone = "This is some information for IPhone4S";

                //Perform calls
                MyGSM.PerformCall(new DateTime(2013, 2, 3), DateTime.Now, "0898654793", 300);
                MyGSM.PerformCall(new DateTime(2013, 2, 7), DateTime.Now, "0898654703", 600);
                MyGSM.PerformCall(new DateTime(2013, 2, 13), DateTime.Now, "0898254793", 200);
                MyGSM.PerformCall(new DateTime(2013, 2, 15), DateTime.Now, "0898647793", 100);
                MyGSM.PerformCall(new DateTime(2013, 2, 16), DateTime.Now, "0898251793", 1300);

                //display history
                Console.WriteLine(MyGSM.DisplayCallHistory());

                //calculate and display calls price
                Console.WriteLine("Calls price is {0:C}\n", MyGSM.CalculateCallsPrice((decimal)0.37));

                //delete history record
                MyGSM.DeleteCall("0898251793");

                //calculate and display calls price again
                Console.WriteLine("Calls price is {0:C}\n", MyGSM.CalculateCallsPrice((decimal)0.37));

                //display history again
                Console.WriteLine(MyGSM.DisplayCallHistory());

                //clear history
                MyGSM.ClearHistory();

                //display history again
                Console.WriteLine(MyGSM.DisplayCallHistory());

                //displaing info
                Console.WriteLine(MyGSM);

                //getting static field value
                Console.WriteLine(GSM.IPhone);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
