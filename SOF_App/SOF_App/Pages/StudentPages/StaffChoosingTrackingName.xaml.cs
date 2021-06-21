using SOF_App.Models;
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
    public partial class StaffChoosingTrackingName : ContentPage
    {

        public StaffChoosingTrackingName()
        {
            InitializeComponent();

            var assembly = typeof(StaffChoosingTrackingName);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            GetStaffName();
        }



        List<string> staffname = new List<string>();
        List<RegisterMember> members;
        public async void GetStaffName()
        {
            ApiServices apiServices = new ApiServices();
             members = await apiServices.GetAllStaffNames();
            
            foreach (var name in members)
            {
                staffname.Add(name.Name);
            }
            StaffNamePicker.ItemsSource = staffname;
        }



        public static string staffName;
        public static string staffID;
        private void StaffNamePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string staffName__;
            if (selectedItem != null)
            {
                staffName__ = (string)selectedItem;
                staffName = staffName__;
                foreach(var id in members)
                {
                    if(staffName == id.Name)
                    {
                        staffID = id.ID;
                        break;

                    }
                }

                Navigation.PushAsync(new StudentAppointmentTracking());
                
            }
            ((Picker)sender).SelectedItem = null;
        }
    }
}