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
    public partial class InsertWorkingHoursforSpecificDays : ContentPage
    {
        public InsertWorkingHoursforSpecificDays()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#444444");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#777777");
           // var assembly = typeof(InsertWorkingHoursforSpecificDays);
           // SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            ServicePicker.IsVisible = true;
        }


        DateTime startDate = InsertDatesForSpecificService.startDate;
        DateTime endDate = InsertDatesForSpecificService.endDate;
        DateTime? startDateWhole = InsertDateForWorkingHours.dateTime_1;
        DateTime? endDateWhole = InsertDateForWorkingHours.dateTime_2;
        string dateType = InsertDateForWorkingHours.dateType;

        public void InsertTimeSlot()
        {

        }

        string dayWorkingType = DaysOfWorking.daysType;
        private async void BtnInsert_Clicked(object sender, EventArgs e)
        {
            string staffID = Settings.ID;
            ApiServices apiServices = new ApiServices();
            //must show error message in case on of the entries were wrong
            try
            {
                string url = "";
                if (serEnt.IsVisible)
                {
                    staffService = serEnt.Text;
                }
                if (dateType == "Insert Appointmets For Working Hours")//
                {
                    if (dayWorkingType == "Every Day")
                    {//teeeeeeest
                        url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots?_startTime={0}&_endTime={1}&_slot={2}&_staffID={3}&_service={4}&_startDate={5}&_endDate={6}&_dateType={7}&_day={8}&_WorkingDaysType={9}&startBreak={10}&endBreak={11}", EntStartTime.Text, EntEndTime.Text, EntTimeSlot.Text, staffID, staffService, startDateWhole, endDateWhole, dateType, day="_", dayWorkingType= "Every Day", 0, 0);

                    }//wrong last things
                    else
                    {//write message in the xaml form to be clear

                        url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots?_startTime={0}&_endTime={1}&_slot={2}&_staffID={3}&_service={4}&_startDate={5}&_endDate={6}&_dateType={7}&_day={8}&_WorkingDaysType={9}&startBreak={10}&endBreak={11}", EntStartTime.Text, EntEndTime.Text, EntTimeSlot.Text, staffID, staffService, startDateWhole, endDateWhole, dateType, day, dayWorkingType="Specific Days", 0, 0);
                        //EntStartTime.Text = null;
                        //EntEndTime.Text = null;
                        //EntTimeSlot.Text = null;
                        //staffService = null;
                    }

                }
                else
                {//wrong link
                    url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots?_startTime={0}&_endTime={1}&_slot={2}&_staffID={3}&_service={4}&_startDate={5}&_endDate={6}&_dateType={7}&_day={8}&_WorkingDaysType={9}&startBreak={10}&endBreak={11}", EntStartTime.Text, EntEndTime.Text, EntTimeSlot.Text, staffID, staffService, startDateWhole, endDateWhole, dateType, day = "_", dayWorkingType = "_", 0, 0);
                }
                // string url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots?_startTime={0}&_endTime={1}&_slot={2}&_staffID={3}&_service={4}&_startDate={5}&_endDate={6}&_dateType={7}", EntStartTime.Text, EntEndTime.Text, EntTimeSlot.Text, staffID, staffService,startDate,endDate, dateType);
                var response = await apiServices.GetNumberOfTimeSlot(url);
                if (response != "Invalid")
                {
                    string message = response.Substring(1, response.Length - 2);
                    if (dayWorkingType == "Specific Days")
                    {
                        await DisplayAlert("Hi", "Your record has been added" + "\n" + "The number of student you can have: " + message + "\n" + "You can insert another day", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Hi", "Your record has been added" + "\n" + "The number of student you can have: " + message, "OK");
                    }

                }
                else
                {
                    await DisplayAlert("Ooops", "Something wrong...", "Alright");
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                await DisplayAlert("Ooops", "Something wrong...", "Alright");
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
                if (service == "Other")
                {
                    serLbl.IsVisible = true;
                    serEnt.IsVisible = true;
                    // staffService = serEnt.Text;
                }

            }
        }

        private void DatetypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string day;
        private void DayPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;

            if (selectedItem != null)
            {
                day = (string)selectedItem;
            }
        }
    }
}