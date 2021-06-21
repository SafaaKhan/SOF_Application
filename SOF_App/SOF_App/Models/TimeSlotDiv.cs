using SOF_App.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SOF_App.Models
{
   public class TimeSlotDiv
    {
        public int ID { get; set; }
        public string time { get; set; }
        public bool status { get; set; }
        public string staffID { get; set; }
        public int roleNumber { get; set; }
        public string availability { get; set; }
        public string service { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string dateType { get; set; }
        public string WorkingDaysTupe { get; set; }
        public string Day { get; set; }

        internal void changeAvailability(TimeSlotDiv timeSlotdive , bool status)
        {
            if (status)
            {
                timeSlotdive.availability = "Unavailable";
                UpdateAvailability(timeSlotdive);
                status = false;
            }
         
            
        }

        private void UpdateAvailability(TimeSlotDiv timeSlotdive)
        {
            var index = TimeSlots.timeSlotDivs.IndexOf(timeSlotdive);
            TimeSlots.timeSlotDivs.Remove(timeSlotdive);
            TimeSlots.timeSlotDivs.Insert(index, timeSlotdive);

        }

       /* public static explicit operator TimeSlotDiv(ListView v)
        {
            return (TimeSlotDiv)v;
        }*/
    }
}
