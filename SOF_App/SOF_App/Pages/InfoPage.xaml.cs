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
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();

            var assembly = typeof(InfoPage);
            facebook.Source = ImageSource.FromResource("SOF_App.Assets.Image.facebook.png", assembly);
            instagram.Source = ImageSource.FromResource("SOF_App.Assets.Image.instagram.png", assembly);
            twitter.Source = ImageSource.FromResource("SOF_App.Assets.Image.twitter.png", assembly);
        }

        private void TapFaceBook_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.facebook.com/pg/AOU_SAB-342267105865492/posts/"));
        }

        private void Tapinstagram_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.instagram.com/aou_ksab/"));
        }

        private void Taptwitter_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://twitter.com/AOU_KSAB/status/1018390378821640192"));
        }
    }
}