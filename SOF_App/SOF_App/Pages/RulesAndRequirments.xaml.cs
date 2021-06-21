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
    public partial class RulesAndRequirments : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await Navigation.PushAsync(new FormInquiry((int)TransactionType.NewStudent));
           // await Navigation.PushAsync(new FormInquiry((int)TransactionType.Normal));

        }
        public  RulesAndRequirments()
        {
            InitializeComponent();
           
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
         Navigation.PushAsync(new Pages.ApplicationForm());
            //Navigation.PushAsync(new NormalStudents());//when the student press
        }
    }
}