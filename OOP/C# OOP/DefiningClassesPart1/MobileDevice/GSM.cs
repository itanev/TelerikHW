using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice
{
    public class GSM
    {
        //Fields
        private string model;
        private string manufacturer;
        private float? price;
        private string owner;
        private Battery battery;
        private Display display;
        private static string IPhone4S;
        private List<Call> allCalls = new List<Call>();

        //Static Property for Iphone4S
        public static string IPhone
        {
            get { return IPhone4S; }
            set { IPhone4S = value; }
        }

        //Property for model
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        //Property for model
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }

        //Property for price
        public float? Price
        {
            get { return this.price; }
            set
            {
                //validate
                if (value < 0)
                {
                    throw new ArgumentException("Invalid value! GSM price must be zero ot gratter.");
                }
                this.price = value;
            }
        }

        //Property for owner
        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        //default constructor
        public GSM( string model, string manufacturer, string batteryModel )
            : this( model, manufacturer, null, null, batteryModel, null, null, null, null, null )
        {
        }

        //constructor + price
        public GSM(string model, string manufacturer, string batteryModel, float price)
            : this(model, manufacturer, price, null, batteryModel, null, null, null, null, null)
        {
        }

        //constructor + owner
        public GSM(string model, string manufacturer, string batteryModel, float price, string owner)
            : this(model, manufacturer, price, owner, batteryModel, null, null, null, null, null)
        {
        }

        //constructor + hoursIdle
        public GSM(string model, string manufacturer, string batteryModel,
            float price, string owner, float hoursIdle)
            : this(model, manufacturer, price, owner, batteryModel, hoursIdle, null, null, null, null)
        {
        }

        //constructor + hoursTalk
        public GSM(string model, string manufacturer, string batteryModel,
            float price, string owner, float hoursIdle, float hoursTalk)
            : this(model, manufacturer, price, owner, batteryModel, hoursIdle, 
                    hoursTalk, null, null, null)
        {
        }

        //constructor + batteryType
        public GSM(string model, string manufacturer, string batteryModel,
            float price, string owner, float hoursIdle, float hoursTalk, BatteryType batteryType)
            : this(model, manufacturer, price, owner, batteryModel, hoursIdle,
                    hoursTalk, batteryType, null, null)
        {
        }

        //constructor + display size
        public GSM(string model, string manufacturer, string batteryModel,
            float price, string owner, float hoursIdle, float hoursTalk, BatteryType batteryType,
            int size)
            : this(model, manufacturer, price, owner, batteryModel, hoursIdle,
                    hoursTalk, batteryType, size, null)
        {
        }

        //constructor with all the info
        public GSM( string model, string manufacturer, float? price, string owner, 
            string batteryModel, float? hoursIdle, float? hoursTalk, BatteryType? batteryType,
            int? size, long? numberColors)
        {
            this.Model = model;
            this.Manufacturer = manufacturer; 
            this.Price = price;
            this.Owner = owner;
            this.battery = new Battery(batteryModel, hoursIdle, hoursTalk, batteryType);
            this.display = new Display(size, numberColors);
        }

        //perform call method
        public void PerformCall(DateTime date, DateTime time, string phoneNumber, long duration)
        {
            allCalls.Add(new Call(date, time, phoneNumber, duration));
        }

        //delete call method by phoneNumber
        public void DeleteCall(string phoneNumber)
        {
            for (int i = 0; i < allCalls.Count; i++)
            {
                if (allCalls[i].phoneNumber.Equals(phoneNumber))
                {
                    allCalls.RemoveAt(i);
                }
            }
        }

        //clear history method
        public void ClearHistory()
        {
            allCalls.Clear();
        }

        //DisplayCallHistory method
        public string DisplayCallHistory()
        {
            StringBuilder history = new StringBuilder();

            foreach (var call in allCalls)
            {
                history.AppendFormat("Call:\n");
                history.AppendFormat("Date: {0}\n", call.date.ToString());
                history.AppendFormat("Time: {0}\n", call.time.ToString());
                history.AppendFormat("Duration: {0}\n", call.duration);
                history.AppendFormat("Talked with: {0}\n\n", call.phoneNumber);
            }

            return history.ToString();
        }

        //Calculate total price of the calls
        public decimal CalculateCallsPrice(decimal pricePerMinute)
        {
            decimal totalPrice = 0;

            foreach (var call in allCalls)
            {
                totalPrice += ((decimal)call.duration / 60) * pricePerMinute;
            }

            return totalPrice;
        }

        //override ToString()
        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.AppendFormat("Model: {0}\n", this.model);
            message.AppendFormat("Manufacturer: {0}\n", this.manufacturer);
            message.AppendFormat("Price: {0}\n", this.price);
            message.AppendFormat("Owner: {0}\n", this.owner);
            message.AppendFormat("\nBattery Information\n");
            message.AppendFormat("Model: {0}\n", this.battery.Model);
            message.AppendFormat("Hours Idle: {0}\n", this.battery.HoursIdle);
            message.AppendFormat("Hours Talk: {0}\n", this.battery.HoursTalk);
            message.AppendFormat("Battery Type: {0}\n", this.battery.BatteryType);
            message.AppendFormat("\nDisplay Information\n");
            message.AppendFormat("Size: {0}\n", this.display.Size);
            message.AppendFormat("Number of colors: {0}\n", this.display.NumberColors);

            return message.ToString();
        }
    }
}
