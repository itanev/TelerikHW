using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    public class Battery
    {
        //Fields
        private string model;
        private float? hoursIdle;
        private float? hoursTalk;
        private BatteryType? batteryType;

        //Property for model field
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        //Property for hoursIdle field
        public float? HoursIdle
        {
            get { return this.hoursIdle; }
            set 
            {
                //validate
                if (value < 0)
                {
                    throw new ArgumentException("Invalid value! Hours idle must be zero or gratter.");
                }
                this.hoursIdle = value;
            }
        }

        //Property for hoursTalk field
        public float? HoursTalk
        {
            get { return this.hoursTalk; }
            //validate
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid value! Hours talk must be zero or gratter.");
                }
                this.hoursTalk = value;
            }
        }

        //Property for Battery Type
        public BatteryType? BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }

        //default constructor
        public Battery(string model)
            : this(model, null, null, null)
        {
        }

        //constructor + hoursIdle
        public Battery(string model, float hoursIdle)
            : this(model, hoursIdle, null, null)
        {
        }

        //constructor + hoursTalk
        public Battery(string model, float hoursIdle, float hoursTalk)
            : this(model, hoursIdle, hoursTalk, null)
        {
        }

        //constructor with all the info
        public Battery(string model, float? hoursIdle, float? hoursTalk, BatteryType? batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }
    }
}
