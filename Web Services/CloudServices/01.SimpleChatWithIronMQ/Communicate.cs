using io.iron.ironmq;
using io.iron.ironmq.Data;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.SimpleChatWithIronMQ
{
    public class Communicate
    {
        private Queue firstUserMessages;
        private Queue secondUserMessages;
        private string senderName;

        public Communicate(Queue firstUserMessages, Queue secondUserMessages, string senderName)
        {
            this.firstUserMessages = firstUserMessages;
            this.secondUserMessages = secondUserMessages;
            this.senderName = senderName;
        }

        public void SendMessage()
        {
            while (true)
            {
                string message = Console.ReadLine();
                this.secondUserMessages.push(message);
            }
        }

        public void GetMessage()
        {
            while (true)
            {
                Message msg = this.firstUserMessages.get();

                while (msg != null)
                {
                    Console.WriteLine("{1}: {0}", msg.Body, senderName);
                    this.firstUserMessages.deleteMessage(msg);
                    Thread.Sleep(50);
                    msg = this.firstUserMessages.get();
                }
            }
        }
    }
}
