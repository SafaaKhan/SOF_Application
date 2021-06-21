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
    public partial class InsertDateForWorkingHours : ContentPage
    {
        public InsertDateForWorkingHours()
        {
            InitializeComponent();

           
        }
        public static string dateType = AcademicMasterDetailPageAppointment.dateType;
        public void DateSetting()
        {
            DateTime? dateTime_1 = calendar_1.SelectedDate;


           
          
            DateTime? dateTime_2 = calendar_2.SelectedDate;

        }
       public static DateTime? dateTime_1;
       public static DateTime? dateTime_2;
        private void NextBtn_Clicked(object sender, EventArgs e)
        {
             dateTime_1 =calendar_1.SelectedDate;


           // string year = dateTime_1.ToString();
          //  string month;
          //  string day;
            dateTime_2 = calendar_2.SelectedDate;
            string memberType = FirstPage.membertype;
            if (memberType != "Academic" && Settings.Type != "Academic")
            {
                Navigation.PushAsync(new InsertWorkinghoursPage());
            }
            else
            {
                Navigation.PushAsync(new DaysOfWorking());
            }
         
        }
    }
}