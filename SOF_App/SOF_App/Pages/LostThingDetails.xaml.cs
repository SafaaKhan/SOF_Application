using Plugin.Messaging;
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
    public partial class LostThingDetails : ContentPage
    {

      private Task<string> _email;

        public async Task<string> GetEmail(int ID)
        {
            try
            {
                ApiServices apiServices = new ApiServices();
                var url = string.Format("https://newmysofapplication.conveyor.cloud/api/LostPostings/GetMemberEmail_2?ID={0}", ID);
                var response = await apiServices.GetMemberEmail_2(url);
                var emailString_Start = response.Substring(1, response.Length-2 );
                return emailString_Start;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return "";
            }
        }

        public async Task<string> GetName(int ID)
        {
            try
            {
                ApiServices apiServices = new ApiServices();
                var url = string.Format("https://newmysofapplication.conveyor.cloud/api/LostPostings/GetMemberEmail_2?ID={0}", ID);
                var response = await apiServices.GetMemberEmail_2(url);
                var emailString_Start = response.Substring(1, response.Length - 2);
                return emailString_Start;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return "";
            }
        }



        public  LostThingDetails(LostThingsPostModel lostThingsPostModel)
        {
            InitializeComponent();
            var assembly = typeof(LostThingDetails);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            EmailIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.email.png", assembly);
            LablResponsibleName.Text = lostThingsPostModel.ResponsibleName;
            LblInfo.Text = lostThingsPostModel.Information;
            LblDate.Text = (lostThingsPostModel.Date).ToString();
            int ID = lostThingsPostModel.ID;
            _email = GetEmail(ID);
         



        }

       private async  void TapEmail_Tapped(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail( await _email, "Add a subject", "Write email body");

                
            }
        }
    }
}