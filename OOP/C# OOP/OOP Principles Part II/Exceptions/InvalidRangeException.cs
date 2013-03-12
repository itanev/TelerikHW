using System;

namespace Exceptions
{
    public class InvalidRangeException<T> : Exception
    {
        private T up;
        private T down;

        public T Down { get; set; }
        public T Up { get; set; }

        public InvalidRangeException(string msg, T up, T down)
            : base(msg)
        {
            this.Down = down;
            this.up = up;
        }
    }
}
