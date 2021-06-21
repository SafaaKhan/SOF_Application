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
    enum TransactionType
    {
        NewStudent = 1,
        Normal = 2
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormInquiry : ContentPage
    {



        int _Type = FirstPage.type;
        public FormInquiry(int Type)
        {
           if(_Type != 0)
            {
                _Type = FirstPage.type; 
            }
           
            InitializeComponent();
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
           
            try
            {
                if (_Type == (int)TransactionType.NewStudent)
                {
                    var res = await ApiServices.GetAsync<FormModel>(String.Format(App.UrlPath
                        + "api/RegistrationForms/GetTransactionStatus?FormID={0}", FormID.Text));
                    if (res != null)
                    {
                        StatusLabel.Text = res.EntStatus;
                        StatusLabel.BackgroundColor = res.BackColor;
                    }
                    else
                    {
                        StatusLabel.Text = "Not Found";
                        StatusLabel.BackgroundColor = Color.Black;
                    }
                }
                else
                {
                    var res = await ApiServices.GetAsync<NormalTransaction>(String.Format(App.UrlPath
                    + "api/NormalTransactions/GetNormalTransactionStatus?FormID={0}", FormID.Text));
                    //GetPhrase

                    var phrase_ = await ApiServices.GetPhrase(String.Format(App.UrlPath
                    + "api/NormalTransactions/GetNormalTransactionPhrase?FormID={0}", FormID.Text));

                    if (res != null)
                    {
                        StatusLabel.Text = res.EntStatus+ phrase_;
                        StatusLabel.BackgroundColor = res.BackColor;
                    }
                    else
                    {
                        StatusLabel.Text = "Not Found";
                        StatusLabel.BackgroundColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}