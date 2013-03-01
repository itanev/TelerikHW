using System;

namespace Library02
{
    public class Worker : Human
    {
        private float weekSalary;
        private float workHoursPerDay;

        //week salary property
        public float WeekSalary 
        { 
            get 
            {
                return this.weekSalary; 
            }
            set
            {
                this.weekSalary = value;
            }
        }

        //hours per day propery
        public float WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                this.workHoursPerDay = value;
            }
        }

        //constructor
        public Worker(float weekSalary, float workHoursPerDay)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        //calculate money per hour
        public decimal MoneyPerHour()
        {
            return (decimal)(this.WeekSalary / 7) / (decimal)this.WorkHoursPerDay;
        }
    }
}
