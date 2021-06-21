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
    public partial class AdminstratorChoosingPage : ContentPage
    {
        public AdminstratorChoosingPage()
        {
            InitializeComponent();

            var assembly = typeof(VisitorChoosingPage);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            AppointmentIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.appointment.png", assembly);
            TransactionsIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.checklist.png", assembly);
            LineVIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.linev.png", assembly);
            LineHIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.lineh.png", assembly);
        }

        private void AppointmentsTap_Tapped(object sender, EventArgs e)
        {

        }

        private void TransactionsTap_Tapped(object sender, EventArgs e)
        {

        }


        private void TLBLogout_Clicked(object sender, EventArgs e)
        {

            Settings.Password = "";
            Settings.ID = "";
            Settings.Type = null;
            Navigation.InsertPageBefore(new FirstPage(), this);
            Navigation.PopAsync();
        }

        public static string appointmenttype;
        private void appointmentPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string appointment;
            if (selectedItem != null)
            {
                appointment = (string)selectedItem;
                if (appointment == "Insert working Hours")
                {
                    appointmenttype = "Insert working Hours";//picker
                   // DatetypePicker.IsVisible = true;
                    AppointmentLbl.IsVisible = false;
                   // Navigation.PushAsync(new InsertDateForWorkingHours());

                }
                else if (appointment == "Appointment Checking")
                {//new NavigationPage(new SignInPage())
                    appointmenttype = "Appointment Checking";
                    Navigation.PushAsync(new StaffAppointmentList());

                }
                
            }
            ((Picker)sender).SelectedItem = null;

        }

        public static string __dateType;
        private void DatetypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string Datetype = (string)selectedItem;
            if (selectedItem != null)
            {
                if (Datetype == "The whole semester")
                {
                    __dateType = Datetype;
                    Navigation.PushAsync(new InsertDateForWorkingHours());
                }
                else
                {
                    __dateType = Datetype;
                    Navigation.PushAsync(new InsertDatesForSpecificService());
                }
            }
             ((Picker)sender).SelectedItem = null;


        }

        private void AppointmentTap_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AcademicMasterDetailPageAppointment());
        }
    }
}