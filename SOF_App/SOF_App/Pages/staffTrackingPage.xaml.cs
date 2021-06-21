using SOF_App.Pages.StudentPages;
using SOF_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOF_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class staffTrackingPage : ContentPage
    {

        string staffID1 = App.staffID;
        string staffID2 = SignInPage.StaffID;
        string staffID;
        string memberType = StudenMasterDetailPage.memberType;
        public staffTrackingPage()
        {
            InitializeComponent();

            if (staffID1 == null)
            {
                staffID = staffID2;
            }
            else
            {
                staffID = staffID1;
            }

            if(memberType != "Student")
            {
                AvailableBtn.IsVisible = true;
                UnavailableBtn.IsVisible = true;
                StoppedBtn.IsVisible = true;
                BusyBtn.IsVisible = true;
            }
            Fill();
           //message
        }

        ApiServices apiService = new ApiServices();
        public async void Fill()
        {
            
            string staffname = await apiService.GetStaffName(staffID);
            staffName.Text = staffname;

            DateTime date = DateTime.Now;
            DayOfWeek day = date.DayOfWeek;
            DateLbl.Text = date.ToString();
            DayLbl.Text = day.ToString();

            status.Text = "No Status!!!";
            apiService.PostTrackingStaffStatus(staffID, status.Text);
        }

        private  void AvailableBtn_Clicked(object sender, EventArgs e)
        {
            status.Text = "Available";
            apiService.PostTrackingStaffStatus(staffID, "Available");

           // new StudentAppointmentTracking();
           
        }

        private  void StoppedBtn_Clicked(object sender, EventArgs e)
        {
            status.Text = "The students reception is stopped for some time.";
             apiService.PostTrackingStaffStatus(staffID, "The students reception is stopped for some time.");

           // new StudentAppointmentTracking();
        }

        private  void UnavailableBtn_Clicked(object sender, EventArgs e)
        {
            status.Text = "UnAvailable";
             apiService.PostTrackingStaffStatus(staffID, "UnAvailable");

           // new StudentAppointmentTracking();
        }

        private  void BusyBtn_Clicked(object sender, EventArgs e)
        {
            status.Text = "Busy!!! \n There is a student. ";
             apiService.PostTrackingStaffStatus(staffID, "Busy!!! \n There is a student. ");
            //new StudentAppointmentTracking();
        }

       
    }
}