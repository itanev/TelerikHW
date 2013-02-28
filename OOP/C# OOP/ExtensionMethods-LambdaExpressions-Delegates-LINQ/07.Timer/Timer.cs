using System;
using System.Threading;

class Timer
{
    //delegate
    delegate void myTimer(int t);

    static void Main()
    {
        myTimer timer = delegate(int time)  //anonymous method
        {
            Thread.Sleep(time);
            Console.WriteLine("ActionExecuted");
        };

        //infinite loop that executes the method through the delegate
        while(true)
        {
            timer(1000);
        }
    }
}