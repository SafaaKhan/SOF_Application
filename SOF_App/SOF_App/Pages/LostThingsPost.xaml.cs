using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOF_App.Models;
using SOF_App.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOF_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LostThingsPost : ContentPage
    {
        public LostThingsPost()
        {
            InitializeComponent();
        }

        static DateTime _dateTime = DateTime.Now;
       // int d = Convert.ToInt32(_dateTime.ToOADate());


        private async void PublishBtn_Clicked(object sender, EventArgs e)
        {
            var PostL = new LostThingsPostModel()
            {
                ResponsibleName = EntResponsibleName.Text,
                Information = EntInformation.Text,
                Date = _dateTime
            };

            string memberID = Settings.ID;


            ApiServices apiServices = new ApiServices();
           bool response= await apiServices.PublishLostThing(PostL,memberID );
            if (!response)
            {
                await DisplayAlert("Alert", "Something Wrong", "Cancel");
            }
            else
            {
                await DisplayAlert("Hi", "Your record has been added seccussfully", "OK");
            }
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