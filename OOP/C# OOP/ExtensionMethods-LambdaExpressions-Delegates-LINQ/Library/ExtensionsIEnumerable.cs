using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class ExtensionsIEnumerable
    {
        //methods work for type that make sence - for example product does not work for string
        //You must predifine opperator in order to work but this isn't part of the ex.

        //extension method sum
        public static dynamic Sum<T>(this IEnumerable<T> colection)
        {
            dynamic col = colection.First();
            int i = 0;

            foreach (var item in colection)
            {
                if (i != 0)
                {
                    col += item;
                }
                i++;
            }

            return col;
        }

        //extension method product
        public static dynamic Product<T>(this IEnumerable<T> colection)
        {
            dynamic col = colection.First();
            int i = 0;

            foreach (var item in colection)
            {
                if (i != 0)
                {
                    col *= item;
                }
                i++;
            }

            return col;
        }

        //extension method min
        public static dynamic Min<T>(this IEnumerable<T> colection)
        {
            dynamic min = colection.First();

            foreach (var item in colection)
            {
                if (item < min)
                {
                    min = item;
                }
            }

            return min;
        }

        //extension method max
        public static dynamic Max<T>(this IEnumerable<T> colection)
        {
            dynamic max = colection.First();

            foreach (var item in colection)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        //extension method average
        public static dynamic Average<T>(this IEnumerable<T> colection)
        {
            dynamic col = colection.First();
            int i = 0;

            foreach (var item in colection)
            {
                if (i != 0)
                {
                    col += item;
                }
                i++;
            }

            return (double)col/i;
        }
    }
}
