using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SimpleChatWithPubNub
{
    class Program
    {
        static void Main(string[] args)
        {
            PubnubAPI pubnub = new PubnubAPI(
                "pub-c-2902e1f0-71b1-44ff-a438-11d120ed8bcf",               // PUBLISH_KEY
                "sub-c-92dac9b8-0747-11e3-9163-02ee2ddab7fe",               // SUBSCRIBE_KEY
                "sec-c-M2RjZmI0OTUtOGU1MC00Mzg1LThjMTQtYjQ4ZmU1YWQ4NzU5",   // SECRET_KEY
                true                                                        // SSL_ON?
            );

            Console.WriteLine("Enter chanel name: ");
            string chanel = Console.ReadLine();

            Console.WriteLine("Enter message: ");
            string msg = Console.ReadLine();
            pubnub.Publish(chanel, msg);

            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                 () =>
                 pubnub.Subscribe(
                     "chat",
                     delegate(object message)
                     {
                         Console.WriteLine("Received Message -> '" + message + "'");
                         return true;
                     }
                 )
             );

            t.Start();
        }
    }
}
