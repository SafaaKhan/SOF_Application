using SOF_App.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using Microsoft.AppCenter.Push;

namespace SOF_App
{
    public partial class App : Application
    {
        public static String UrlPath { get; internal set; } = "https://newmysofapplication.conveyor.cloud/";
        public static string  studentID;
        public static string staffID;
        public App()
        {
            InitializeComponent();

            if(!string.IsNullOrEmpty(Settings.ID) && !string.IsNullOrEmpty(Settings.Password))
            {
               
              if( Settings.Type.Equals("club"))
                {
                    MainPage = new NavigationPage(new ClubAndSCHomePage());
              }
              else if(Settings.Type.Equals("security"))
                {
                    MainPage = new NavigationPage(new LostThingsPost());
                }
                else if (Settings.Type.Equals("Normal Student"))
                {
                    studentID = Settings.ID;
                    MainPage = new NavigationPage(new Pages.StudentPages.StudenMasterDetailPage());
                }
                else if (Settings.Type.Equals("Adminstrator") || Settings.Type.Equals("Academic"))
                {
                    staffID = Settings.ID;
                    MainPage = new NavigationPage(new AcademicMasterDetailPageAppointment());
                }
              //Later edit it
               // else if (Settings.Type.Equals("Academic"))
              //  {
                //    MainPage = new NavigationPage(new AdminstratorChoosingPage());
               // }
            }

            else
            {
                MainPage = new NavigationPage(new FirstPage());
            }
            






            /*

            // MainPage = new NavigationPage (new FirstPage());
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                // MainPage = new NavigationPage(new FirstPage());
                //clubs
                MainPage = new NavigationPage(new PostCSc());
                //security
               // MainPage = new NavigationPage(new LostThingsPost());
            }
            else
            {
                MainPage = new NavigationPage(new FirstPage());
            }*/
        }

        protected override void OnStart()
        {

           // AppCenter.Start("android=b0a0b10e-d365-4ce7-8fa6-bda890284155", typeof(Analytics));
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
