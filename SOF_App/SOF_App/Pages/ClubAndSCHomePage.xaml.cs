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
    public partial class ClubAndSCHomePage : ContentPage
    {
        public ClubAndSCHomePage()
        {
            InitializeComponent();
            var assembly = typeof(VisitorChoosingPage);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            ClubsEventsNewsIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.LostFoundIcon.png", assembly);
            PostEventsNews.Source = ImageSource.FromResource("SOF_App.Assets.Image.PostNEIcon.png", assembly);
            LineVIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.linev.png", assembly);
            LineHIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.lineh.png", assembly);
        }

        private void ClubsEventsNewsTap_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventsNewsListPage());
        }

        private void PostEventsNews_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PostCSc());
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