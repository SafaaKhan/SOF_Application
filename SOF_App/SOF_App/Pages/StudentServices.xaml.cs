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
    public partial class StudentServices : ContentPage
    {
        List<NormalTransaction> lstNormalTransaction;
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lstNormalTransaction = await ApiServices.GetAsync<List<NormalTransaction>>(App.UrlPath + "api/NormalTransactions/GetNormalTransaction");
            lsvTransaction.ItemsSource = lstNormalTransaction;

        }
        public StudentServices()
        {
            InitializeComponent();
           
        }

        public async void normarl()
        {
            lstNormalTransaction = await ApiServices.GetAsync<List<NormalTransaction>>(App.UrlPath + "api/NormalTransactions/GetNormalTransaction");
        }
        private void lsvContinuing_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void lstvGraduate_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private async void lsvTransaction_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var obj = e.Item as NormalTransaction;
                await Navigation.PushAsync(new NormalTransactionDetails(obj));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}
