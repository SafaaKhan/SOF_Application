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
    public partial class Admission_Officer : ContentPage
    {
        List<FormModel> lstRegistrationForms;
        protected override async void OnAppearing()
        {
            //new student for adminstrator
            base.OnAppearing();
            try
            {
                lstRegistrationForms = await ApiServices.GetAsync<List<FormModel>>("https://newmysofapplication.conveyor.cloud/" + "api/RegistrationForms/Get");
                lstVStudents.ItemsSource = lstRegistrationForms;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
        public Admission_Officer()
        {
            InitializeComponent();
        }

        private async void lstVStudents_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var obj = e.Item as FormModel;
                await Navigation.PushAsync(new Forms_Details(obj));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}