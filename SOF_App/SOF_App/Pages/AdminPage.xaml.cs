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
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
           
        }

        public void DateSetting()
        {
          DateTime? dateTime_1=  calendar_1.SelectedDate;
           

           string year= dateTime_1.ToString();
            string month;
            string day;
          DateTime? dateTime_2 = calendar_1.SelectedDate;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DateSetting();
        }

        //button
    }
}