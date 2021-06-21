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
    public partial class YourServices : ContentPage
    {
        string staffID1 = App.staffID;
        string staffID2 = SignInPage.StaffID;
      public static  string staffID;
        static public ObservableCollection<TimeSlot> TimeSlots;
        List<int> service;
        public YourServices()
        {
            InitializeComponent();
           
            var assembly = typeof(YourServices);
            DeleteIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.deleteViewIcone.png", assembly);
            TimeSlots = new ObservableCollection<TimeSlot>();
            service = new List<int>();

            if (staffID1 == null)
            {
                staffID = staffID2;
            }
            else
            {
                staffID = staffID1;
            }

            GetServiceInfo();
           
        }



        private async void GetServiceInfo()
        {
            ApiServices apiServices = new ApiServices();
           
            var _timeslot = await apiServices.GetTimeSlotInfo_2(staffID);

            foreach (var service in _timeslot)
            {

                TimeSlots.Add(service);

            }


            ServiceInfoList.ItemsSource = TimeSlots;

        }








        int _id;
        private async void DeleteTap_Tapped(object sender, EventArgs e)
        {
            var acceptBtn = await DisplayAlert("Hi", "All List Will be removed", "OK", "CANCEL");
            if (acceptBtn)
            {
                //List_studentReservedAppointmentsCancelled
                foreach (var id in TimeSlots)
                {
                    
                    service.Add(id.ID);
                }
                ApiServices apiServices = new ApiServices();
                apiServices.DeleteServices(service);//if(response
                await DisplayAlert("Hi", "The services has been deleted", "OK");
                TimeSlots = new ObservableCollection<TimeSlot>();
                GetServiceInfo();
            }
            else
            {
                await DisplayAlert("OK", "The list will not be removed", "Alright");
            }
        }



       


        private void ServiceInfoList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var service = BindingContext as TimeSlot;
            var serviceSelected = e.Item as TimeSlot;
            service.HideOrShowAppointment(serviceSelected);
        }


     

      public static  int startTime;
        public static int endtTime;
        public static int slots;
        public static string _service;
        public static DateTime startDate;
        public static DateTime endDate;
        public static string dateType;
        public static string Day;
        public static string __service;
        public static string WorkingDaysTupe;

        private void ServiceInfoList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedServices = e.SelectedItem as TimeSlot;
           
            if (selectedServices != null)
            {
                _id = selectedServices.ID;
                startTime = selectedServices.startTime;
                endtTime = selectedServices.endtTime;
                slots = selectedServices.slots;
                _service = selectedServices.service;
                startDate = selectedServices.startDate;
                endDate = selectedServices.endDate;
                dateType = selectedServices.dateType;
                Day = selectedServices.Day;
                WorkingDaysTupe = selectedServices.WorkingDaysTupe;
                __service = selectedServices.service;
            }

           ((ListView)sender).SelectedItem = null;
        }



        private async void deleteBtn_Clicked(object sender, EventArgs e)
        {
            var acceptBtn = await DisplayAlert("Hi", "The service will be deleted", "OK", "CANCEL");
            if (acceptBtn)
            {
                ApiServices apiServices = new ApiServices();
                bool response = await apiServices.DeleteSpecificService(_id);
                if (response)
                {
                    await DisplayAlert("Hi", "The service has been deleted", "OK");
                    TimeSlots = new ObservableCollection<TimeSlot>();
                    GetServiceInfo();
                }
                else
                {
                    await DisplayAlert("Ooops", "There is something wrong", "OK");
                }
            }
            else
            {
                await DisplayAlert("OK", "The service will not be deleted", "Alright");
            }
        }

        

        private void UpdateBtn_Clicked(object sender, EventArgs e)
        {
            //  Navigation.PushAsync(new UpdateAppointmentForAService());
            //DisablePage
            Navigation.PushAsync(new DisablePage());
        }
    }
}