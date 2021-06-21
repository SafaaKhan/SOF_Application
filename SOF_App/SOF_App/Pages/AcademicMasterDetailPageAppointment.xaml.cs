
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
    public partial class AcademicMasterDetailPageAppointment : MasterDetailPage
    {
        public AcademicMasterDetailPageAppointment()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
          //  Master.BackgroundColor = Color.FromHex("#eeeeee");
          //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#444444");
         // ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#777777");
            //change bar color 
            var assembly = typeof(AcademicMasterDetailPageAppointment);
            HomeIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.HomeIcon.png", assembly);
            ServiceIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.ServiceIcon.png", assembly);
            AppointmentIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.AppointmentIcom.png", assembly);
            InsertIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.InsertIcon.png", assembly);
            Insert2Icon.Source = ImageSource.FromResource("SOF_App.Assets.Image.InsertIcon.png", assembly);
            LogoutIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.logoutIcon.png", assembly);
            TracingIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.track.png", assembly);
            CheckListIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.checklist.png", assembly);
            CheckingregistrationofnewstudentIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.checklist.png", assembly);
            PostingIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.PostNEIcon.png", assembly);
            string memberType = FirstPage.membertype;
            if(memberType== "Academic" || Settings.Type== "Academic")
            {
                specific_serviceStck.IsVisible = true;
                CheckingregistrationofnewstudentSTCK.IsVisible = false;
                postStk.IsVisible = false;
            }
        }


        public static string dateType;

        private void checkingTap_Tapped(object sender, EventArgs e)
        {
            Detail =new NavigationPage(new StaffAppointmentList());
            IsPresented = false;
        }

        private void ServicesTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new YourServices());
            IsPresented = false;
        }


        private void WorkingHoursTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new InsertDateForWorkingHours());
            dateType = WorkingHoursLbl.Text;
            IsPresented = false;
        }

        private void SpecificServicesTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new InsertDatesForSpecificService());
            dateType = SpecificServicesLbl.Text;
            IsPresented = false;
        }

        private void TracingTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new staffTrackingPage());
            IsPresented = false;
        }

        private void HomeTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;
        }

        private void Logout_Tapped(object sender, EventArgs e)
        {
            Settings.Password = "";
            Settings.ID = "";
            Settings.Type = null;
            Navigation.InsertPageBefore(new FirstPage(), this);
            Navigation.PopAsync();
        }

        private void TransactionTap_Tapped(object sender, EventArgs e)
        {
            
            Detail = new NavigationPage(new StudentServices());
            
            IsPresented = false;
        }

        private void Checkingregistrationofnewstudent(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Admission_Officer());
            IsPresented = false;
        }

        private void PostingTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PostCSc());

            IsPresented = false;
        }
    }
}