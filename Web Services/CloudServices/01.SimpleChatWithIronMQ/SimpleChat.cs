using io.iron.ironmq;
using io.iron.ironmq.Data;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.SimpleChatWithIronMQ
{
    class SimpleChat
    {
        static void Main(string[] args)
        {
            // run the exe
            // pesho
            // kiro
            // rerun the exe
            // kiro
            // pesho
            Console.WriteLine("Enter your chanel name: ");
            string senderChanelName = Console.ReadLine();

            Console.WriteLine("Enter chanel name for the user you want to chat with: ");
            string receiverChanelName = Console.ReadLine();

            Client client = new Client("520f6b22cd2e16000d00000c", "oC7j96AKY9NcuPfVpLOnZm-zTzU");
            Queue receiverChanel = client.queue(receiverChanelName);
            Queue senderChanel = client.queue(senderChanelName);

            Communicate communication = new Communicate(senderChanel, receiverChanel, senderChanelName);

            Thread sender = new Thread(new ThreadStart(communication.SendMessage));
            Thread receiver = new Thread(new ThreadStart(communication.GetMessage));

            sender.Start();
            receiver.Start();
        }
    }
}
