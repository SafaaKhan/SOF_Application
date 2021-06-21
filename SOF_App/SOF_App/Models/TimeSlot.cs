using SOF_App.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOF_App.Models
{
  public  class TimeSlot
    {
        public int ID { get; set; }
        public string staffID { get; set; }
        public int startTime { get; set; }
        public int endtTime { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string dateType { get; set; }
        public int slots { get; set; }
        public string service { get; set; }
        public string  WorkingDaysTupe { get; set; }
        public string Day { get; set; }
        public int breakstartTime { get; set; }
        public int breakendtTime { get; set; }
        public DateTime disableStartDate { get; set; }
        public DateTime disableEndDate { get; set; }
        public bool disablestatus { get; set; }
        public string disableMSG { get; set; }

        private TimeSlot _oldAppointment;

        public bool isVisibale { get; set; }
        int index_1;
        //public void count(StudentReservedAppointment appointmentSelected)
        //{
        //    index_1 = AppointmentCheckingPage.studentReservedAppointments.IndexOf(appointmentSelected);
        //    if (index_1 < 0)
        //    {
        //        index_1++;
        //    }
        //    HideOrShowAppointment(appointmentSelected);
        //}

        internal void HideOrShowAppointment(TimeSlot TimeSlotSelected)
        {
            
                if (_oldAppointment == TimeSlotSelected)
                {
                // click twice on the same item will hide it
                TimeSlotSelected.isVisibale = !TimeSlotSelected.isVisibale;
                    UpdateAppointment(TimeSlotSelected);
                }
                else
                {
                    if (_oldAppointment != null)
                    {
                        // hide previous selected item
                        _oldAppointment.isVisibale = false;
                        UpdateAppointment(TimeSlotSelected);
                    }
                // show selected item
                TimeSlotSelected.isVisibale = true;
                    UpdateAppointment(TimeSlotSelected);

                }
                _oldAppointment = TimeSlotSelected;

        }


        private void UpdateAppointment(TimeSlot TimeSlotSelected)
        {

           int index_1 = YourServices.TimeSlots.IndexOf(TimeSlotSelected);
            YourServices.TimeSlots.Remove(TimeSlotSelected);
            YourServices.TimeSlots.Insert(index_1, TimeSlotSelected);

        }

    }
}
