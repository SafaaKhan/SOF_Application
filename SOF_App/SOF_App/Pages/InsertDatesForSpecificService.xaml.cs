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
    public partial class InsertDatesForSpecificService : ContentPage
    {
        public InsertDatesForSpecificService()
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



        public static string dateType ;
        public static string dayWorkingType ;
   
        private void NextBtn_Clicked(object sender, EventArgs e)
        {
            dateType = "Insert Appointmets For Specific Services";
            dayWorkingType = "_";
            Navigation.PushAsync(new InsertWorkinghoursPage());
        }


        List<DateTime> blackoutDates = new List<DateTime>();
        
        private void calendar_OnMonthCellLoaded_1(object sender, Syncfusion.SfCalendar.XForms.MonthCellLoadedEventArgs e)
        {

            var dayOfWeek = e.Date.DayOfWeek;


            if ( dayOfWeek == DayOfWeek.Friday)
            {
                blackoutDates.Add(e.Date);


            }
            calendar.BlackoutDates = blackoutDates;
        }

      

    }
}