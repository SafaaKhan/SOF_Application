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

namespace SOF_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdditionalStaffServices : ContentPage
    {
        public ObservableCollection<string> timeSlotDivs;
        public AdditionalStaffServices()
        {
            InitializeComponent();
            var assembly = typeof(LostThingDetails);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            timeSlotDivs = new ObservableCollection<string>();
            GettimeSlotDivs();
        }

        
        string _staffName = StuffChoosingPage.staffName;

        public async void GettimeSlotDivs()
        {
           
            ApiServices apiServices = new ApiServices();
            var timeSlotDivsInfo = await apiServices.GetTimeSlotDivInfo_2(_staffName);//16

           
            foreach (var _timeSlot in timeSlotDivsInfo)
            {
               
                if (!timeSlotDivs.Contains(_timeSlot.service))
                {
                    timeSlotDivs.Add(_timeSlot.service);
                }
            }
            if(timeSlotDivs.Count != 0)
            {
                ServicePicker.ItemsSource = timeSlotDivs;
            }
            else
            {
              await  DisplayAlert("Sorry", "There is no available service for the tutor", "OK");
            }
           



        }


        static public string staffService;
        private void ServicePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string service;
            if (selectedItem != null)
            {
                service = (string)selectedItem;
                staffService = service;
                Navigation.PushAsync(new TimeSlots());

            }

           
                ((Picker)sender).SelectedItem = null;
        }
    }
}//test for admin