using SOF_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOF_App.Pages.StudentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentAppointmentTracking : ContentPage
    {
        //string staffID1 = App.staffID;
        // string staffID2 = SignInPage.StaffID;
        string staffID = StaffChoosingTrackingName.staffID;
        //access from mulitple page
        string memberType = StudenMasterDetailPage.memberType;
        public StudentAppointmentTracking()
        {
            InitializeComponent();
            //if (staffID1 == null)
            //{
            //    staffID = staffID2;
            //}
            //else
            //{
            //    staffID = staffID1;
            //}
           // staffID = "288999";

            
           
            Fill();

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                // If you want to update UI, make sure its on the on the main thread.
                // Otherwise, you can remove the BeginInvokeOnMainThread
                Device.BeginInvokeOnMainThread(() => Fill());
                return true;
            });
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

            // status.Text = "No Status!!!";
            //test
            status.Text = await apiService.GetStafftrackingstatus(staffID);

           
        }

        
    }
}