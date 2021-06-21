using SOF_App.Models;
using SOF_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOF_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalTransactionDetails : ContentPage
    {
        NormalTransaction _detailsObj;
        public NormalTransactionDetails(NormalTransaction detailsObj)
        {
            _detailsObj = detailsObj;
            InitializeComponent();

            DetailsEntContinuingSt.SelectedItem = detailsObj.EntContinuingSt;
            DetailsEntGraduateSt.SelectedItem = detailsObj.EntGraduateSt;
            DetailsEntIdC.Text = detailsObj.EntIdC;
            DetailsEntIdG.Text = detailsObj.EntIdG;
            DetailsEntNameG.Text = detailsObj.EntNameG;
            DetailsEntNameC.Text = detailsObj.EntNameC;
            DetailsEntEmailC.Text = detailsObj.EntEmailC;
            DetailsEntEmailG.Text = detailsObj.EntEmailG;
            DetailslbContinuing.Text = detailsObj.lbContinuing;
            DetailslbGraduate.Text = detailsObj.lbGraduate;
            DetailsEntcontinuosTransaction.Text = detailsObj.EntcontinuosTransaction;
            DetailsEntGraduateTransaction.Text = detailsObj.EntGraduateTransaction;
            DetailsMajorC.Text = detailsObj.MajorC;
            if (detailsObj.GraduatedORContinuing == "Graduate Student")
            {
                DetailsstkGraduate.IsVisible = true;
            }
            else
            {
                DetailsstkContinuing.IsVisible = true;
            }
        }
        private void CotinueOnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if (DetailsEntContinuingSt.SelectedItem.ToString() == "Other TransAction")
                DetailsstkOtherC.IsVisible = true;
            else
                DetailsstkOtherC.IsVisible = false;
        }

        private void GraduateOnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if (DetailsEntGraduateSt.SelectedItem.ToString() == "Other TransAction")
                DetailsstkOtherG.IsVisible = true;
            else
                DetailsstkOtherG.IsVisible = false;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await Launcher.CanOpenAsync(new Uri(App.UrlPath + "Files/" + _detailsObj.FilePath)))
                await Launcher.OpenAsync(new Uri(App.UrlPath + "Files/" + _detailsObj.FilePath));
        }

        string staffID1 = App.staffID;
        string staffID2 = SignInPage.StaffID;
        string staffID;
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (staffID1 == null)
            {
                staffID = staffID2;
            }
            else
            {
                staffID = staffID1;
            }
            ApiServices apiService = new ApiServices();
            string staffname = await apiService.GetStaffName(staffID);
            String staffEmail = await apiService.GetstaffEmail(staffname);

            var sen = sender as Button;
            var hh = _detailsObj;
            string p = "\n The staff name: " + staffname + " \n The Staff Email: " + staffEmail;
            var res = await ApiServices.GetAsync<int>(String.Format(App.UrlPath + "api/NormalTransactions/ChangeNormalTransactionStatus?FormID={0}&Status={1}&email={2}&phrase={3}", hh.ID, sen.ClassId, hh.GraduatedORContinuing == "Graduate Student" ? hh.EntEmailG : hh.EntEmailC, p));
            if (res == 1)
            {
                await DisplayAlert(" ", "Done", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}