using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolunarFishing
{
    internal class ConvertTime
    {
        public static string TwentyFourToTwelveHour(string time)
        {
            string[] timeParts;
            string hours;
            timeParts = time.Split(":");
            hours = timeParts[0];
            int hoursInteger = int.Parse(hours);
            if(hoursInteger <= 12)
                return time += " AM";
            else
            {
                hours = (hoursInteger - 12).ToString();
                return hours += ":" + timeParts[1] + " PM";
            }

        }
    }
}
