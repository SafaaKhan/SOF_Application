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
    public partial class FirstPage : ContentPage
    {
        
        public FirstPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            var assembly = typeof(SignInPage);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            VisitorIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.visitor.png", assembly);
            MemberIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.member.png", assembly);
            LineVIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.linev.png", assembly);
            LineHIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.lineh.png", assembly);
            StudentIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.student.png", assembly);
            InfoIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.question.png", assembly);
           // BackgroundImageSource = "SOFLogoAOU.png";
        }

        private void VisitorTap_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisitorChoosingPage());
        }

       /* private void MemberTap_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage());
        }*/

        
        private void InfoTap_Tapped(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new InfoPage());
        }

       public static string membertype;

        private void MemberPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string member;
            if(selectedItem != null)
            {
                member= (string)selectedItem;
                if(member == "Club and Student Council")
                {
                    membertype = "club";
                    Navigation.PushAsync( new SignInPage());
                   
                }
                else if (member == "Security")
                {//new NavigationPage(new SignInPage())
                    membertype = "security";
                    Navigation.PushAsync(new SignInPage());
                   
                }
                else if (member == "Normal Student")
                {
                    membertype = "Normal Student";
                    Navigation.PushAsync(new SignInPage());

                }
                else if (member == "Adminstrator" || member== "Academic")
                {
                    membertype = member;
                    Navigation.PushAsync(new SignInPage());

                }
            }
            ((Picker)sender).SelectedItem = null;
          

        }

        private void AdminTap_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InfoPage());
        }

        public static int type;
        private void NewStudentTap_Tapped(object sender, EventArgs e)
        {
            NewStudentPicker.IsVisible = true;
            type = 1;
          //  Navigation.PushAsync(new RulesAndRequirments());
         //   Navigation.PushAsync(new ApplicationForm());
        }

        private void MemberTap_Tapped(object sender, EventArgs e)
        {
            MemberPicker.IsVisible = true;
        }

        private void NewStudentPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string selection;
            if (selectedItem != null)
            {
                selection = (string)selectedItem;
                if (selection == "Enroll in University")
                {

                    Navigation.PushAsync(new RulesAndRequirments());

                }
                else if (selection == "Tracking The Request")
                {
               
                    Navigation.PushAsync(new FormInquiry((int)TransactionType.Normal));

                }
               
             
            }
            ((Picker)sender).SelectedItem = null;

        }
        /*
private void TLBLogout_Clicked(object sender, EventArgs e)
{
Settings.AccessToken = "";
Settings.Password = "";
Settings.UserName = "";
Navigation.InsertPageBefore(new SignInPage(), this);
Navigation.PopAsync();

}*/
    }
}