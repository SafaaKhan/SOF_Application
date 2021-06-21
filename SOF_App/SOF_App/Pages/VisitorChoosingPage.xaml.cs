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
    public partial class VisitorChoosingPage : ContentPage
    {
        public VisitorChoosingPage()
        {
            InitializeComponent();
            var assembly = typeof(VisitorChoosingPage);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            ClubsEventsNewsIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.LostFoundIcon.png", assembly);
            LostandFoundIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.newsIcon.png", assembly);
            LineVIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.linev.png", assembly);
            LineHIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.lineh.png", assembly);
        }

        private  void ClubsEventsNewsTap_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventsNewsListPage());
        }

        private void LostandFoundTap_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LostThingsPostList());
        }
    }
}