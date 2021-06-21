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
    public partial class InsertWorkinghoursPage : ContentPage
    {
        public InsertWorkinghoursPage()
        {
            InitializeComponent();
           // var assembly = typeof(SignInPage);
          //  SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            
            if(memberType== "Academic" || Settings.Type == "Academic")
            {
                ServicePicker.IsVisible = true;
            }
            if(dayWorkingType_2 == "_")
            {
                dayWorkingType = "_";
            }
            if (dayWorkingType == "Every Day" || (memberType != "Academic" && memberType!=null) || Settings.Type != "Academic")
            {
                _1Lbl.IsVisible = true;
                _2Lbl.IsVisible = true;
                _3Lbl.IsVisible = true;
                _4Lbl.IsVisible = true;
                _5Lbl.IsVisible = true;
                _6Lbl.IsVisible = true;
                _7Lbl.IsVisible = true;
                Exp1.IsVisible = true;
                Exp2.IsVisible = true;
            }
        }

        string memberType = FirstPage.membertype;
        DateTime startDate =InsertDatesForSpecificService.startDate;
         DateTime endDate= InsertDatesForSpecificService.endDate;
        DateTime? startDateWhole = InsertDateForWorkingHours.dateTime_1;
        DateTime? endDateWhole =InsertDateForWorkingHours.dateTime_2;
        string dateType = InsertDateForWorkingHours.dateType;
       string dateType_2 = InsertDatesForSpecificService.dateType;
        string url;
        string dayWorkingType = DaysOfWorking.daysType;
        string dayWorkingType_2 = InsertDatesForSpecificService.dayWorkingType;
        private async void BtnInsert_Clicked(object sender, EventArgs e)
        {
           // string staffID = Settings.ID;//change
            string staffID1 = App.staffID;
            string staffID2 = SignInPage.StaffID;
            string staffID;
            string day;
            ApiServices apiServices = new ApiServices();
            //must show error message in case on of the entries were wrong
            try
            {
                if (staffID1 == null)
                {
                    staffID = staffID2;
                }
                else
                {
                    staffID = staffID1;
                }
              
                if (memberType == "Academic" || Settings.Type == "Academic")
                {

                    memberType = "Academic";
                    if (dateType_2 != null)
                    {
                        dateType = dateType_2;
                    }

                    

                    if (serEnt.IsVisible)
                    {
                        staffService = serEnt.Text;
                    }
                    if (dateType == "Insert Appointmets For Working Hours")
                    {
                        if (dayWorkingType == "Every Day")
                        {//teeeeeeest
                            url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots?_startTime={0}&_endTime={1}&_slot={2}&_staffID={3}&_service={4}&_startDate={5}&_endDate={6}&_dateType={7}&_day={8}&_WorkingDaysType={9}&startBreak={10}&endBreak={11}", EntStartTime.Text, EntEndTime.Text, EntTimeSlot.Text, staffID, staffService, startDateWhole, endDateWhole, dateType, day = "_", dayWorkingType = "Every Day", _4Lbl.Text, _6Lbl.Text);

                        }
                        //else
                        //{//write message in the xaml form to be clear

                        //    url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots?_startTime={0}&_endTime={1}&_slot={2}&_staffID={3}&_service={4}&_startDate={5}&_endDate={6}&_dateType={7}&_day={8}&_WorkingDaysType={9}", EntStartTime.Text, EntEndTime.Text, EntTimeSlot.Text, staffID, staffService, startDateWhole, endDateWhole, dateType, day, dayWorkingType);
                        //    EntStartTime.Text = null;
                        //    EntEndTime.Text = null;
                        //    EntTimeSlot.Text = null;
                        //    staffService = null;
                        //}
                    }
                    else
                    {
                        url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots?_startTime={0}&_endTime={1}&_slot={2}&_staffID={3}&_service={4}&_startDate={5}&_endDate={6}&_dateType={7}&_day={8}&_WorkingDaysType={9}&startBreak={10}&endBreak={11}", EntStartTime.Text, EntEndTime.Text, EntTimeSlot.Text, staffID, staffService, startDate, endDate, dateType, day = "_", dayWorkingType, 0, 0);
                    }
                    // string url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots?_startTime={0}&_endTime={1}&_slot={2}&_staffID={3}&_service={4}&_startDate={5}&_endDate={6}&_dateType={7}", EntStartTime.Text, EntEndTime.Text, EntTimeSlot.Text, staffID, staffService,startDate,endDate, dateType);
                    var response = await apiServices.GetNumberOfTimeSlot(url);
                    if (response != "Invalid")
                    {
                        string message = response.Substring(1, response.Length - 2);
                        await DisplayAlert("Hi", "Your record has been added" + "\n" + "The number of student you can have: " + message, "OK");
                    }
                    else
                    {
                        await DisplayAlert("Ooops", "Something wrong...", "Alright");
                    }
                }
                else
                {
                    string url_1 = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetAdminstratorService?staffID={0}", staffID);
                    string _staffService = await apiServices.GetAdminstratorService(url_1);
                    url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots?_startTime={0}&_endTime={1}&_slot={2}&_staffID={3}&_service={4}&_startDate={5}&_endDate={6}&_dateType={7}&_day={8}&_WorkingDaysType={9}&startBreak={10}&endBreak={11}", EntStartTime.Text, EntEndTime.Text, EntTimeSlot.Text, staffID, _staffService, startDateWhole, endDateWhole, dateType, day = "_", dayWorkingType = "_", _4Lbl.Text, _6Lbl.Text);
                    var response = await apiServices.GetNumberOfTimeSlot(url);
                    if (response != "\"Invalid\"")
                    {
                        string message = response.Substring(1, response.Length - 2);
                        await DisplayAlert("Hi", "Your record has been added" + "\n" + "The number of student you can have: " + message, "OK");
                    }
                    else
                    {
                        await DisplayAlert("Ooops", "Something wrong...", "Alright");
                    }
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
    }
}