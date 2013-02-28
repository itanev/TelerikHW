using System;
using System.Text;

namespace Library
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder str, int index, int length)
        {
            StringBuilder output = new StringBuilder();

            output.Append(str.ToString().Substring(index, length));
            
            return output;
        }
    }
}
