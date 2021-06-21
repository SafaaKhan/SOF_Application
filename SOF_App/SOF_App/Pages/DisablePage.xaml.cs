using SOF_App.Models;
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
    public partial class DisablePage : ContentPage
    {
        public DisablePage()
        {
            InitializeComponent();
        }


        static public DateTime startDate;
        static public DateTime endDate;
        private void calendar_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {

            IList<DateTime> date = e.DateAdded;
            startDate = date[0];
            endDate = date[date.Count() - 1];
        }


        List<DateTime> blackoutDates = new List<DateTime>();
        private void calendar_OnMonthCellLoaded_1(object sender, Syncfusion.SfCalendar.XForms.MonthCellLoadedEventArgs e)
        {
            var dayOfWeek = e.Date.DayOfWeek;


            if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Friday)
            {
                blackoutDates.Add(e.Date);


            }
            calendar.BlackoutDates = blackoutDates;
        }


        public static int startTime= YourServices.startTime;
        public static int endtTime = YourServices.endtTime;
        public static int slots= YourServices.slots;
        public static string _service = YourServices.__service;
        public static DateTime _startDate = YourServices.startDate;
        public static DateTime _endDate = YourServices.endDate;
        public static string dateType= YourServices.dateType;
        public static string Day = YourServices.Day;
        public static string WorkingDaysTupe = YourServices.WorkingDaysTupe;
        public static string staffID = YourServices.staffID;
        

        private async void DoneBtn_Clicked(object sender, EventArgs e)
        {
            ApiServices apiServices = new ApiServices();
          string url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/UpdateDisabling?_startTime={0}&_endTime={1}&_slot={2}&_staffID={3}&_service={4}&_startDate={5}&_endDate={6}&_dateType={7}&_day={8}&_WorkingDaysType={9}&disableStartDate={10}&disableEndDate={11}&disableMSG={12}", startTime , endtTime, slots, staffID, _service, _startDate, _endDate, dateType, Day, WorkingDaysTupe, startDate , endDate, msgEnt.Text);
           bool response= await apiServices.UpdateAppointmentDisable(url);
            if (response)
            {
               await DisplayAlert("Hi", "The changed has been done", "OK");
            }
            else
            {
                await DisplayAlert("Oops", "Something wrong...", "OK");
            }
        }
    }
}