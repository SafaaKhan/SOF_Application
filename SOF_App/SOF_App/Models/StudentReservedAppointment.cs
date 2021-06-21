using SOF_App.Pages;
using SOF_App.Pages.StudentPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOF_App.Models
{
    public class StudentReservedAppointment
    {
        public int ID { get; set; }
        public string studentID { get; set; }//t
        public string studentName { get; set; }
        public string StudentEmail { get; set; }
        public string staffName { get; set; }
        public string serviceName { get; set; }
        public string Date { get; set; }//t
        public string Time { get; set; }//t
        public bool status { get; set; }
        public string isDone { get; set; }
        public int roleNumber { get; set; }
        public string availability { get; set; }
        public string WorkingDaysTupe { get; set; }
        public string Day { get; set; }
        public string isDoneby { get; set; }
        public string isCancelledby { get; set; }

        private StudentReservedAppointment _oldAppointment;

        public bool isVisibale { get; set; }
        int index_1;
        public void count(StudentReservedAppointment appointmentSelected)
        {
            index_1 = AppointmentCheckingPage.studentReservedAppointments.IndexOf(appointmentSelected);
            if (index_1 < 0)
            {
                index_1++;
            }
            HideOrShowAppointment(appointmentSelected);
        }

       

        internal void HideOrShowAppointment(StudentReservedAppointment appointmentSelected)
        {
            if (appointmentSelected.isDone == "Done")
            {
                if (_oldAppointment == appointmentSelected)
                {
                    // click twice on the same item will hide it
                    appointmentSelected.isVisibale = !appointmentSelected.isVisibale;
                    UpdateAppointment_Done(appointmentSelected);
                }
                else
                {
                    if (_oldAppointment != null)
                    {
                        // hide previous selected item
                        _oldAppointment.isVisibale = false;
                        UpdateAppointment_Done(_oldAppointment);
                    }
                    // show selected item
                    appointmentSelected.isVisibale = true;
                    UpdateAppointment_Done(appointmentSelected);

                }
                _oldAppointment = appointmentSelected;

            }
            else if (appointmentSelected.isDone == "Cancel")
            {
                if (_oldAppointment == appointmentSelected)
                {
                    // click twice on the same item will hide it
                    appointmentSelected.isVisibale = !appointmentSelected.isVisibale;
                    UpdateAppointment_Cancel(appointmentSelected);
                }
                else
                {
                    if (_oldAppointment != null)
                    {
                        // hide previous selected item
                        _oldAppointment.isVisibale = false;
                        UpdateAppointment_Cancel(_oldAppointment);
                    }
                    // show selected item
                    appointmentSelected.isVisibale = true;
                    UpdateAppointment_Cancel(appointmentSelected);

                }
                _oldAppointment = appointmentSelected;

            }
            else
            {
                if (_oldAppointment == appointmentSelected)
                {
                    // click twice on the same item will hide it
                    appointmentSelected.isVisibale = !appointmentSelected.isVisibale;
                    UpdateAppointment(appointmentSelected);
                }
                else
                {
                    if (_oldAppointment != null)
                    {
                        // hide previous selected item
                        _oldAppointment.isVisibale = false;
                        UpdateAppointment(_oldAppointment);
                    }
                    // show selected item
                    appointmentSelected.isVisibale = true;
                    UpdateAppointment(appointmentSelected);

                }
                _oldAppointment = appointmentSelected;

            }


           
           
        }





        /// <summary>
        /// this os of student List
        /// </summary>
        /// <param name="appointmentSelected"></param>


        public void count_Stu(StudentReservedAppointment appointmentSelected)
        {
            index_1 = WaitingAppointmentStudent.studentReservedAppointments.IndexOf(appointmentSelected);
            if (index_1 < 0)
            {
                index_1++;
            }
            HideOrShowAppointment_stu(appointmentSelected);
        }

        private void UpdateAppointment_stu(StudentReservedAppointment appointmentSelected)
        {


            WaitingAppointmentStudent.studentReservedAppointments.Remove(appointmentSelected);
            WaitingAppointmentStudent.studentReservedAppointments.Insert(index_1, appointmentSelected);

        }




        internal void HideOrShowAppointment_stu(StudentReservedAppointment appointmentSelected)
        {
            if (appointmentSelected.isDone == "Done")
            {
                if (_oldAppointment == appointmentSelected)
                {
                    // click twice on the same item will hide it
                    appointmentSelected.isVisibale = !appointmentSelected.isVisibale;
                    UpdateAppointment_Done_Stu(appointmentSelected);
                }
                else
                {
                    if (_oldAppointment != null)
                    {
                        // hide previous selected item
                        _oldAppointment.isVisibale = false;
                        UpdateAppointment_Done_Stu(_oldAppointment);
                    }
                    // show selected item
                    appointmentSelected.isVisibale = true;
                    UpdateAppointment_Done_Stu(appointmentSelected);

                }
                _oldAppointment = appointmentSelected;

            }
            else if (appointmentSelected.isDone == "Cancel")
            {
                if (_oldAppointment == appointmentSelected)
                {
                    // click twice on the same item will hide it
                    appointmentSelected.isVisibale = !appointmentSelected.isVisibale;
                    UpdateAppointment_Cancel(appointmentSelected);
                }
                else
                {
                    if (_oldAppointment != null)
                    {
                        // hide previous selected item
                        _oldAppointment.isVisibale = false;
                        UpdateAppointment_Cancel(_oldAppointment);
                    }
                    // show selected item
                    appointmentSelected.isVisibale = true;
                    UpdateAppointment_Cancel(appointmentSelected);

                }
                _oldAppointment = appointmentSelected;

            }
            else
            {
                if (_oldAppointment == appointmentSelected)
                {
                    // click twice on the same item will hide it
                    appointmentSelected.isVisibale = !appointmentSelected.isVisibale;
                    UpdateAppointment_stu(appointmentSelected);
                }
                else
                {
                    if (_oldAppointment != null)
                    {
                        // hide previous selected item
                        _oldAppointment.isVisibale = false;
                        UpdateAppointment_stu(_oldAppointment);
                    }
                    // show selected item
                    appointmentSelected.isVisibale = true;
                    UpdateAppointment_stu(appointmentSelected);

                }
                _oldAppointment = appointmentSelected;

            }




        }

        private void UpdateAppointment_Done_Stu(StudentReservedAppointment appointmentSelected)
        {
            var index = DoneAppointmentStudent.studentReservedAppointmentsDone.IndexOf(appointmentSelected);
            DoneAppointmentStudent.studentReservedAppointmentsDone.Remove(appointmentSelected);
            DoneAppointmentStudent.studentReservedAppointmentsDone.Insert(index, appointmentSelected);
        }
        private void UpdateAppointment_Cancel_stu(StudentReservedAppointment appointmentSelected)
        {
            var index = CancelAppointmentStudent.studentReservedAppointmentsCancelled.IndexOf(appointmentSelected);
            CancelAppointmentStudent.studentReservedAppointmentsCancelled.Remove(appointmentSelected);
            CancelAppointmentStudent.studentReservedAppointmentsCancelled.Insert(index, appointmentSelected);
        }

        /// <summary>
        /// //////////end of studnet
        /// </summary>
        /// <param name="appointmentSelected"></param>












        private void UpdateAppointment(StudentReservedAppointment appointmentSelected)
        {
           
           
            AppointmentCheckingPage.studentReservedAppointments.Remove(appointmentSelected);
            AppointmentCheckingPage.studentReservedAppointments.Insert(index_1, appointmentSelected);
           
        }

        private void UpdateAppointment_Done(StudentReservedAppointment appointmentSelected)
        {
            var index = DoneAppointmentListStaff.studentReservedAppointmentsDone.IndexOf(appointmentSelected);
            DoneAppointmentListStaff.studentReservedAppointmentsDone.Remove(appointmentSelected);
            DoneAppointmentListStaff.studentReservedAppointmentsDone.Insert(index, appointmentSelected);
        }
        private void UpdateAppointment_Cancel(StudentReservedAppointment appointmentSelected)
        {
            var index = CancelledAppointmentListStaff.studentReservedAppointmentsCancelled.IndexOf(appointmentSelected);
            CancelledAppointmentListStaff.studentReservedAppointmentsCancelled.Remove(appointmentSelected);
            CancelledAppointmentListStaff.studentReservedAppointmentsCancelled.Insert(index, appointmentSelected);
        }
    }
}
