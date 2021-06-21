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
    public partial class CancelAppointmentStudent : ContentPage
    {
        static public ObservableCollection<StudentReservedAppointment> studentReservedAppointmentsCancelled;

        List<int> students;

        string studentID1 = App.studentID;
        string studentID2 = SignInPage.studentID;
        string studentID;
        public CancelAppointmentStudent()
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
            students = new List<int>();
            var assembly = typeof(CancelledAppointmentListStaff);
            DeleteIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.deleteViewIcone.png", assembly);
            studentReservedAppointmentsCancelled = new ObservableCollection<StudentReservedAppointment>();
            GetStudentInfo();
        }

        private async void GetStudentInfo()
        {
            ApiServices apiServices = new ApiServices();
            var studentAppointment = await apiServices.GetStudentAppointmentInfoStu(studentID);//staffID
            var studentAppointmentDone = await apiServices.GetStudentAppointmentInfoStu_Done(studentID);
            var studentAppointmentCancel = await apiServices.GetStudentAppointmentInfo_CancelStu(studentID);

            foreach (var student in studentAppointmentCancel)
            {

                studentReservedAppointmentsCancelled.Add(student);

            }

            waitingLbl.Text = studentAppointment.Count.ToString();
            DoneLbl.Text = studentAppointmentDone.Count.ToString();
            cancelledLbl.Text = studentReservedAppointmentsCancelled.Count.ToString();
            StudentBooedAppointmnetInfor.ItemsSource = studentReservedAppointmentsCancelled;

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



        //private void StudentBooedAppointmnetInfor_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var appointment = BindingContext as StudentReservedAppointment;
        //    var appointmentSelected = e.Item as StudentReservedAppointment;
        //    //  appointment.HideOrShowAppointment(appointmentSelected);
        //    appointment.HideOrShowAppointment_stu(appointmentSelected);

        //}




        private async void DeleteTap_Tapped(object sender, EventArgs e)
        {
            var acceptBtn = await DisplayAlert("Hi", "All list will be removed", "OK", "CANCEL");
            if (acceptBtn)
            {
                //List_studentReservedAppointmentsCancelled
                foreach (var id in studentReservedAppointmentsCancelled)
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
                await DisplayAlert("OK", "The list will not be removed", "Alright");
            }
        }

       

        
    }
}