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
    public partial class NormalStudentTransactionsChoosing : ContentPage
    {
        public NormalStudentTransactionsChoosing()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            var assembly = typeof(NormalStudentTransactionsChoosing);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
        }

        private void TransactionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        
        }

        private void TLBLogout_Clicked(object sender, EventArgs e)
        {

            Settings.Password = "";
            Settings.ID = "";
            Settings.Type = null;
            Navigation.InsertPageBefore(new FirstPage(), this);
            Navigation.PopAsync();
        }



    }
}