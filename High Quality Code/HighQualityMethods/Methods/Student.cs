namespace Methods
{
    using System;

    public class Student
    {
        private readonly int dateLength = 10;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student otherStudent)
        {
            DateTime firstDate = ParseDate(this.OtherInfo, this.dateLength);
            DateTime secondDate = ParseDate(this.OtherInfo, this.dateLength);

            bool isFirstDateBigger = false;

            if (firstDate > secondDate)
            {
                isFirstDateBigger = true;
            }

            return isFirstDateBigger;
        }

        private int DateStartIndex(int infoLength, int dateLength)
        {
            int index = infoLength - dateLength;

            return index;
        }

        private DateTime ParseDate(string dateContainer, int dateLength)
        {
            string actualDate = dateContainer.Substring(DateStartIndex(dateContainer.Length, dateLength));

            DateTime parsedDate = DateTime.Parse(actualDate);

            return parsedDate;
        }
    }
}
