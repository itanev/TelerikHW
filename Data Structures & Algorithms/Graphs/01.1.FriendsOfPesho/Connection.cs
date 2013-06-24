using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._1.FriendsOfPesho
{
    public class Connection
    {
        public Node To {get; set;}
        public int Distance { get; set; }

        public Connection(Node To, int distance)
        {
            this.To = To;
            this.Distance = distance;
        }
    }
}
