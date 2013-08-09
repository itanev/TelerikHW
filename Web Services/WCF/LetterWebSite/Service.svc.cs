using System;
using System.Collections.Generic;
using System.Linq;
using LetterService;

namespace LetterWebSite
{
    public class Service : ILetterService
    {
        public int GetTimes(string firstStr, string secondStr)
        {
            int times = 0;
            int currIndex = -1;

            while ((currIndex = firstStr.IndexOf(secondStr, currIndex + 1)) != -1)
            {
                times++;
            }

            return times;
        }
    }
}
