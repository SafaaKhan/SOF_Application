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

namespace SOF_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointmentCheckingPage : ContentPage
    {

       static public ObservableCollection<StudentReservedAppointment> studentReservedAppointments;


        string staffID1 = App.staffID;
        string staffID2 = SignInPage.StaffID;
        string staffID;
        public  AppointmentCheckingPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#444444");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#777777");


            if (staffID1 == null)
            {
                staffID = staffID2;
            }
            else
            {
                staffID = staffID1;
            }


            studentReservedAppointments = new ObservableCollection<StudentReservedAppointment>();
            GetStudentInfo();
            
        }



        //Label l= StudentInfoThings.FindByName<Label>("STUDENTID");
       


            
        private async void GetStudentInfo()
        {
            ApiServices apiServices = new ApiServices();
            var studentAppointment =await apiServices.GetStudentAppointmentInfo(staffID);//staffID
            var studentAppointmentDone= await apiServices.GetStudentAppointmentInfo_Done(staffID);
            var studentAppointmentCancel = await apiServices.GetStudentAppointmentInfo_Cancel(staffID);

            foreach (var student in studentAppointment) 
            {
               
                studentReservedAppointments.Add(student);
                
            }

            waitingLbl.Text = studentReservedAppointments.Count.ToString();
            DoneLbl.Text = studentAppointmentDone.Count.ToString();
            cancelledLbl.Text = studentAppointmentCancel.Count.ToString();
            StudentInfoThings.ItemsSource = studentReservedAppointments;
         
        }
        //display role num

        StudentReservedAppointment selectedStudent;
        int id;//
        string _email;
        string time;
        string date;
        string staffName;
        string serviceName;
        private void StudentInfoThings_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedAppointment = e.SelectedItem as StudentReservedAppointment;
            if(selectedAppointment != null)
            {
                selectedStudent = selectedAppointment;
                _email = selectedAppointment.StudentEmail;
                serviceName= selectedAppointment.serviceName;
                staffName= selectedAppointment.staffName;
                date= selectedAppointment.Date;
                time= selectedAppointment.Time;
               id = selectedAppointment.ID;

            }
           
            ((ListView)sender).SelectedItem = null;
        }
       
        private void TapEmail_Tapped(object sender, EventArgs e)
        {
            /*  var emailMessenger = CrossMessaging.Current.EmailMessenger;
             if (emailMessenger.CanSendEmail)
             {
                 // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                 emailMessenger.SendEmail(await _email, "Add a subject", "Write email body");


             }*/
        }

        private void StudentInfoThings_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var appointment = BindingContext as StudentReservedAppointment;
            var appointmentSelected = e.Item as StudentReservedAppointment;
            //  appointment.HideOrShowAppointment(appointmentSelected);
             appointment.count(appointmentSelected);

        }

        private void detailsBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StudentAppointmentInfoDetails(selectedStudent));
        }

       

        private void DoneButton_Clicked(object sender, EventArgs e)
        {
            ApiServices apiServices = new ApiServices();
             apiServices.UpdateAppointmentState(id,"staff");
            studentReservedAppointments = new ObservableCollection<StudentReservedAppointment>();
            GetStudentInfo();

        }

       

        private void DeleteButton_Clicked_1(object sender, EventArgs e)
        {

            Email();
            ApiServices apiServices = new ApiServices();
            apiServices.CancelAppointmentState(id, "staff");
            studentReservedAppointments = new ObservableCollection<StudentReservedAppointment>();
            GetStudentInfo();
        }

        public void Email()
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;//email from the labtop?????/
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail(_email, "The Appointment has been cancelled", "This email is send to inform you the appointmet has been booked in "+date+" at "+time+ " of the service: "+ serviceName+" with "+staffName +" is cancelled. ");


            }
        }
    }
    }