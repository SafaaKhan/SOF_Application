using SOF_App.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOF_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalStusentPage : ContentPage
    {


        public NormalStusentPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
           
            var assembly = typeof(LostThingDetails);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            GetStaffsServices();
        }

        List<string> services = new List<string>();
        public async void GetStaffsServices()
        {
            ApiServices apiServices = new ApiServices();
          var response= await apiServices.GetStaffServices();
            services.Add("Academic Services");
            foreach(var service_ in response)
            {
                if ((!services.Contains(service_)) && service_ != "_")
                {
                    services.Add(service_);
                }
            }

            if(services.Count != 0)
            {
                SevicePicker.ItemsSource = services;
            }
            else
            {
                await DisplayAlert("Sorry", "There is no available service...", "OK");
            }
        }


        

        public static string servicetype;
        public static bool adminstratorMember;
        private void SevicePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string service;
            
            if (selectedItem != null)
            {
                service = (string)selectedItem;
                if (service == "Academic Services")
                {
                    servicetype = "Academic Services";
                    Navigation.PushAsync(new DepartmetChoosingPage());

                }
                else
                {
                    servicetype = service;
                    adminstratorMember = true;
                      Navigation.PushAsync(new StuffChoosingPage());
                }
                //else if (service == "Booking Book")
                //{

                //}
                //else if(service== "Finance")
                //{
                //    servicetype = "Finance";
                //    Navigation.PushAsync(new StuffChoosingPage());
                //}
            }
            ((Picker)sender).SelectedItem = null;

        }

        private void TransactionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}