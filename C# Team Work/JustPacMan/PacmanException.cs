using System;

namespace JustPacMan
{
    public class PacmanException : ApplicationException
    {
        public PacmanException()
            : base()
        {
        }

        public PacmanException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public PacmanException(string message)
            : this(message, null)
        {
        }
    }
}
