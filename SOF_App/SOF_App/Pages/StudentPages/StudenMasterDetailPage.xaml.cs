using SOF_App.Models;
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
    public partial class StudenMasterDetailPage : MasterDetailPage
    {
        public StudenMasterDetailPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            Master.BackgroundColor = Color.FromHex("#EFFBFB");
            var assembly = typeof(AcademicMasterDetailPageAppointment);
            // HomeIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.HomeIcon.png", assembly);
            newsIconIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.newsIcon.png", assembly);
            AppointmentIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.AppointmentIcom.png", assembly);
            LostFoundIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.LostFoundIcon.png", assembly);
            transactionIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.transaction.png", assembly);
            logoutIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.logoutIcon.png", assembly);
            trackIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.track.png", assembly);
            trackIcon1.Source = ImageSource.FromResource("SOF_App.Assets.Image.track.png", assembly);
            appointmentIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.appointment.png", assembly);
        }

    

        private void Logout_Tapped(object sender, EventArgs e)
        {
            Settings.Password = "";
            Settings.ID = "";
            Settings.Type = null;
            Navigation.InsertPageBefore(new FirstPage(), this);
            Navigation.PopAsync();
        }

        private void ClubsEventsandNewsTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new EventsNewsListPage());
            IsPresented = false;
        }

        private void LostThingsTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new LostThingsPostList());
            IsPresented = false;
        }

        private void BookingAppointmentTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new NormalStusentPage());
            IsPresented = false;
        }

        private void TransactionTap_Tapped(object sender, EventArgs e)
        {
            // Detail = new NavigationPage(new NormalStudentTransactionsChoosing());
            Detail = new NavigationPage(new NormalStudents());
            IsPresented = false;
        }

        private void BookedAppointmentsTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new BookedAppointment());
            IsPresented = false;
        }

        public static string memberType;
        private void AppointmentTracingTap_Tapped(object sender, EventArgs e)
        {
            memberType = "Student";
            Detail = new NavigationPage(new StaffChoosingTrackingName());
            IsPresented = false;
        }

        private void TransactionTracingTap_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new FormInquiry((int)TransactionType.Normal));
            IsPresented = false;
            
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as StudenMasterDetailPageMasterMenuItem;
        //    if (item == null)
        //        return;

        //    var page = (Page)Activator.CreateInstance(item.TargetType);
        //    page.Title = item.Title;

        //    Detail = new NavigationPage(page);
        //    IsPresented = false;

        //    MasterPage.ListView.SelectedItem = null;
        //}
    }
}