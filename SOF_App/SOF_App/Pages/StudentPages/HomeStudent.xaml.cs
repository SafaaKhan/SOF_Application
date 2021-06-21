using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOF_App.Pages.StudentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeStudent : ContentPage
    {
        public HomeStudent()
        {
            InitializeComponent();
            var assembly = typeof(HomePage);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
        }

        private void TLBLogout_Clicked(object sender, EventArgs e)
        {

        }
    }
}