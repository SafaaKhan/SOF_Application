using Plugin.Messaging;
using SOF_App.Models;
using SOF_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOF_App.Pages.StudentPages
{

   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaitingAppointmentStudent : ContentPage
    {
        string studentID1 = App.studentID;
        string studentID2 = SignInPage.studentID;
        string studentID;
        static public ObservableCollection<StudentReservedAppointment> studentReservedAppointments;

        public WaitingAppointmentStudent()
        {
            InitializeComponent();

            if (studentID1 == null)
            {
                studentID = studentID2;
            }
            else
            {
                studentID = studentID1;
            }

            studentReservedAppointments = new ObservableCollection<StudentReservedAppointment>();
            GetStudentInfo();
        }


        private async void GetStudentInfo()
        {
            ApiServices apiServices = new ApiServices();
            var studentAppointment = await apiServices.GetStudentAppointmentInfoStu(studentID);//staffID
            var studentAppointmentDone = await apiServices.GetStudentAppointmentInfoStu_Done(studentID);
            var studentAppointmentCancel = await apiServices.GetStudentAppointmentInfo_CancelStu(studentID);

            foreach (var student in studentAppointment)
            {

                studentReservedAppointments.Add(student);

            }

            waitingLbl.Text = studentReservedAppointments.Count.ToString();
            DoneLbl.Text = studentAppointmentDone.Count.ToString();
            cancelledLbl.Text = studentAppointmentCancel.Count.ToString();
            StudentBooedAppointmnetInfor.ItemsSource = studentReservedAppointments;

        }

        StudentReservedAppointment selectedStudent;
        int id;//
        
        string time;
        string date;
        string staffName;
        string serviceName;
        private void StudentBooedAppointmnetInfor_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var selectedAppointment = e.SelectedItem as StudentReservedAppointment;
            if (selectedAppointment != null)
            {
                selectedStudent = selectedAppointment;
               
                serviceName = selectedAppointment.serviceName;
                staffName = selectedAppointment.staffName;
                date = selectedAppointment.Date;
                time = selectedAppointment.Time;
                id = selectedAppointment.ID;

            }

            ((ListView)sender).SelectedItem = null;
        }

        private void StudentBooedAppointmnetInfor_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var appointment = BindingContext as StudentReservedAppointment;
            var appointmentSelected = e.Item as StudentReservedAppointment;
            //  appointment.HideOrShowAppointment(appointmentSelected);
            appointment.count_Stu(appointmentSelected);

        }

        private void DeleteButton_Clicked_1(object sender, EventArgs e)
        {

            Email();
            ApiServices apiServices = new ApiServices();
            apiServices.CancelAppointmentState(id,"student");
            studentReservedAppointments = new ObservableCollection<StudentReservedAppointment>();
            GetStudentInfo();
        }

        private void DoneButton_Clicked(object sender, EventArgs e)
        {
            ApiServices apiServices = new ApiServices();
            apiServices.UpdateAppointmentState(id,"student");
            studentReservedAppointments = new ObservableCollection<StudentReservedAppointment>();
            GetStudentInfo();


        }


        public async void Email()
        {
            ApiServices apiServices = new ApiServices();
              string _email= await apiServices.GetstaffEmail(staffName);
            var emailMessenger = CrossMessaging.Current.EmailMessenger;//email from the labtop?????/
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail(_email, "The Appointment has been cancelled", "This email is send to inform you the appointmet has been booked in " + date + " at " + time + " of the service: " + serviceName + " with " + staffName + " is cancelled. ");


            }
        }
    }
}