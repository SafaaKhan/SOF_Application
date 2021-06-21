﻿using SOF_App.Models;
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
    public partial class CancelledAppointmentListStaff : ContentPage
    {
        static public ObservableCollection<StudentReservedAppointment> studentReservedAppointmentsCancelled;

        List<int> students;
        string staffID1 = App.staffID;
        string staffID2 = SignInPage.StaffID;
        string staffID;
        public CancelledAppointmentListStaff()
        {
            InitializeComponent();
            students = new List<int>();
            NavigationPage.SetHasBackButton(this, true);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#444444");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#777777");
            var assembly = typeof(CancelledAppointmentListStaff);
            DeleteIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.deleteViewIcone.png", assembly);

            if (staffID1 == null)
            {
                staffID = staffID2;
            }
            else
            {
                staffID = staffID1;
            }


            studentReservedAppointmentsCancelled = new ObservableCollection<StudentReservedAppointment>();
            GetStudentInfo();
        }


        private async void GetStudentInfo()
        {
            ApiServices apiServices = new ApiServices();
            var studentAppointment = await apiServices.GetStudentAppointmentInfo(staffID);//staffID
            var studentAppointmentDone = await apiServices.GetStudentAppointmentInfo_Done(staffID);
            var studentAppointmentCancel = await apiServices.GetStudentAppointmentInfo_Cancel(staffID);

            foreach (var student in studentAppointmentCancel)
            {

                studentReservedAppointmentsCancelled.Add(student);

            }

            DoneLbl.Text = studentAppointmentDone.Count.ToString();
            waitingLbl.Text = studentAppointment.Count.ToString();
            cancelledLbl.Text = studentAppointmentCancel.Count.ToString();
            StudentInfoThings.ItemsSource = studentReservedAppointmentsCancelled;
            
        }

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
            if (selectedAppointment != null)
            {
                selectedStudent = selectedAppointment;
               
                _email = selectedAppointment.StudentEmail;
                serviceName = selectedAppointment.serviceName;
                staffName = selectedAppointment.staffName;
                date = selectedAppointment.Date;
                time = selectedAppointment.Time;
                id = selectedAppointment.ID;

            }

           ((ListView)sender).SelectedItem = null;
        }



        private void StudentInfoThings_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var appointment = BindingContext as StudentReservedAppointment;
            var appointmentSelected = e.Item as StudentReservedAppointment;
            appointment.HideOrShowAppointment(appointmentSelected);
        }

        private void detailsBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StudentAppointmentInfoDetails(selectedStudent));
            studentReservedAppointmentsCancelled = new ObservableCollection<StudentReservedAppointment>();
            GetStudentInfo();
        }

       

        private async void DeleteTap_Tapped(object sender, EventArgs e)
        {
           var acceptBtn= await DisplayAlert("Hi","All list will be removed","OK","CANCEL");
            if (acceptBtn)
            {
                //List_studentReservedAppointmentsCancelled
                foreach(var id in studentReservedAppointmentsCancelled)
                {
                    students.Add(id.ID);
                }
                ApiServices apiServices = new ApiServices();
                apiServices.DeleteAppoitment(students);
                studentReservedAppointmentsCancelled = new ObservableCollection<StudentReservedAppointment>();
                GetStudentInfo();
            }
            else
            {
                await DisplayAlert("OK", "The list willnot be removed", "Alright");
            }
        
        }
    }
}