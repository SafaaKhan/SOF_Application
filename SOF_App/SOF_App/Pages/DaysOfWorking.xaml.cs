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
    public partial class DaysOfWorking : ContentPage
    {
        public DaysOfWorking()
        {
            InitializeComponent();
            var assembly = typeof(DaysOfWorking);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
        }

       public static string daysType;
        private void DaysTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
           
            if(selectedItem != null)
            {
                daysType = (string)selectedItem;
                if(daysType== "Every Day")
                {
                    Navigation.PushAsync(new InsertWorkinghoursPage());
                }
                else
                {
                    
                    Navigation.PushAsync(new InsertWorkingHoursforSpecificDays());
                }
            }
        }
    }
}