using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    internal class Call
    {
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public string phoneNumber { get; set; }
        public long duration { get; set; }

        public Call(DateTime date, DateTime time, string phoneNumber, long duration)
        {
            this.date = date;
            this.time = time;
            this.phoneNumber = phoneNumber;
            this.duration = duration;
        }
    }
}
