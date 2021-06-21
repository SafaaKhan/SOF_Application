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
    public partial class StuffChoosingPage : ContentPage
    {
        List<string> names;
        string serviceType = NormalStusentPage.servicetype;
        string departmentType = DepartmetChoosingPage.departmentType;

        public StuffChoosingPage()
        {
           
            InitializeComponent();
            var assembly = typeof(LostThingDetails);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            //no need to if????
            //if (serviceType== "Finance")
            //{
            //    GetFinanceStaffName();
            //}
            //else if(serviceType== "Academic Services")
            //{
            //    GetFinanceStaffName();
            //}
            GetStaffName();

        }

        public async void GetStaffName()
        {
            ApiServices apiServices = new ApiServices();
            if (serviceType == "Academic Services")
            {
                names = await apiServices.GetStaffName("_", departmentType);//only here move to addtitional
            }
            else
            {
                names = await apiServices.GetStaffName(serviceType, "_");
            }
         if(names.Count == 0)
            {
               await DisplayAlert("Sorry", "There is no staff has been added...", "OK");
            }
            else
            {
                StaffPicker.ItemsSource = names;
            }
            
        }

        public static string staffName;
        private void StaffPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //take staff name
            //navigate to TimeSlote

            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string staff;
            if (selectedItem != null)
            {
                staff = (string)selectedItem;
                staffName = staff;
                if(serviceType == "Academic Services")
                {
                    Navigation.PushAsync(new AdditionalStaffServices());
                }
                else
                {
                    // Navigation.PushAsync(new TimeSlots());
                    Navigation.PushAsync(new TimeSlots());
                }
          

                /*    if (staff == "Dania AL-Madani")
                    {
                    staffName = staff;
                    Navigation.PushAsync(new TimeSlots());

                    }
                    else if (staff == "Dr.Malak")
                    {

                    }
                    else if(staff == "Ms.Ohoud")
                    {
                        staffName = "Ms.Ohoud";
                        Navigation.PushAsync(new TimeSlots());
                    */
            }
            ((Picker)sender).SelectedItem = null;
        }
    }
}