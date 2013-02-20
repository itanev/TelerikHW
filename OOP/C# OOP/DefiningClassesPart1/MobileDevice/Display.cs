using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    public class Display
    {
        //Fields
        private int? size;
        private long? numberColors;

        //Propery for size Field
        public int? Size
        {
            get { return this.size; }
            set 
            {
                //validate
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid value! Display size must be gratter than zero.");
                }
                this.size = value;
            }
        }

        //Propery for numberColors Field
        public long? NumberColors
        {
            get { return this.numberColors;  }
            set
            {
                //validate
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid value! Number of colors must be gratter then zero.");
                }
                this.numberColors = value;
            }
        }
        
        //default constructor
        public Display()
            : this(null, null)
        {
        }

        //constructor + size
        public Display(int size)
            : this(size, null)
        {
        }

        //constructor with all the info
        public Display(int? size, long? numberColors)
        {
            this.Size = size;
            this.NumberColors = numberColors;
        }
    }
}
