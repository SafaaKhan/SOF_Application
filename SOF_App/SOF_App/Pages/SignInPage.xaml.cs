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
    public partial class SignInPage : ContentPage
    {//try catch
        public SignInPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, true);
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ffd700");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#0066ff");
            var assembly = typeof(SignInPage);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
        }

        public static string studentID;
        public static string adminstratorID;

        public static string StaffID;

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
           
            string memberType = FirstPage.membertype;

            ApiServices apiservice = new ApiServices();
            //  var response=await apiservice.LoginUser_2(EntID.Text, EntPassword.Text);
            //  var SecResponse = await apiservice.SecurityLogin(EntID.Text, EntPassword.Text);

            
          


            if (memberType == "club")
            {
                bool status = false;
                var url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/StudentLogin?Id={0}&password={1}", EntID.Text, EntPassword.Text);
                List<RegisterMember> studentModel = await apiservice.GetClubMember();
                var response = await apiservice.GeneralLogin(url);
                string s2 = response.ToString();

                if (!s2.Equals("\"login is invalid\""))
                {
                   
                    foreach (var ClubStudent in studentModel)
                    {
                        if (ClubStudent.ID == EntID.Text)
                        {
                            //how to delete if posted somethin wrong
                            await Navigation.PushAsync(new NavigationPage(new ClubAndSCHomePage()));
                            status = false;
                            apiservice.externalLogin(EntID.Text, EntPassword.Text,"club");
                            break;
                        }
                        else
                        {
                            status = true;
                        }
                        
                    }
                    if (status == true)
                    {
                        await DisplayAlert("Alert!", " You are not member in any clubs ", "Cancel");
                    }
                }
                else
                {
                    await DisplayAlert("Alert!", "Something wrong... ", "Cancel");
                }


            }
            else if (memberType == "Normal Student")
            {
               
                var url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/StudentLogin?Id={0}&password={1}", EntID.Text, EntPassword.Text);
                 
               // List<RegisterMember> studentModel = await apiservice.GetClubMember();
                var response = await apiservice.GeneralLogin(url);
                string s2 = response.ToString();

                if (!s2.Equals("\"login is invalid\""))
                {
                    studentID = EntID.Text;
                await Navigation.PushAsync(new NavigationPage(new StudentPages.StudenMasterDetailPage()));
                            
                        apiservice.externalLogin(EntID.Text, EntPassword.Text, "Normal Student");

                }
                else
                {
                    await DisplayAlert("Alert!", "Something wrong... ", "Cancel");
                }


            }
            else if (memberType == "security")
            {
                bool status = false;
                var url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/SecurityLogin?password={0}&Id={1}", EntPassword.Text,EntID.Text );

                List<RegisterMember> securityMember = await apiservice.GetSecurityMember();
                var response = await apiservice.GeneralLogin(url);

                if (!response.Equals("\"login is invalid\""))
                {
                    
                    foreach (var _securityMember in securityMember)
                    {
                        if (_securityMember.ID == EntID.Text)
                        {

                            await Navigation.PushAsync(new LostThingsPost());
                            status = false;
                            apiservice.externalLogin(EntID.Text, EntPassword.Text, "security");
                            break;
                        }
                        else
                        {
                            status = true;
                        }
                    }
                    if (status == true)
                    {
                        await DisplayAlert("Alert!", " You are not member in posting lost thing ", "Cancel");
                    }
                }
                else
                {
                    await DisplayAlert("Alert!", "Something wrong...", "Cancel");
                }


            }
            else if (memberType == "Adminstrator" || memberType == "Academic")
            {
                bool status = false;
                var url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/AdminstratorLogin?password={0}&Id={1}", EntPassword.Text, EntID.Text);

                List<RegisterMember> adminstratorMember = await apiservice.GetadminstratorMember();
                var response = await apiservice.GeneralLogin(url);

                if (!response.Equals("\"login is invalid\""))
                {

                    foreach (var _adminstratorMember in adminstratorMember)
                    {
                        if (_adminstratorMember.ID == EntID.Text)
                        {
                            adminstratorID = EntID.Text;
                            StaffID = EntID.Text;
                            await Navigation.PushAsync(new AcademicMasterDetailPageAppointment());
                            status = false;
                            apiservice.externalLogin(EntID.Text, EntPassword.Text, memberType);
                            break;
                        }
                        else
                        {
                            status = true;
                        }
                    }
                    if (status == true)
                    {
                        await DisplayAlert("Alert!", " You are not member in "+ memberType, "Cancel");
                    }
                }
                else
                {
                    await DisplayAlert("Alert!", "Something wrong...", "Cancel");
                }


            }
            else
            {
                await DisplayAlert("Alert!", "Something wrong in ID or password ", "Cancel");
            }

        }

            private void TapSignUp_Tapped(object sender, EventArgs e)
            {
                Navigation.PushAsync(new SignUpPage());
            }
        }
    }
