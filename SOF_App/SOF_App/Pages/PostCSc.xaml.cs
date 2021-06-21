using Plugin.Media;
using Plugin.Media.Abstractions;
using SOF_App.Helper;
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
    public partial class PostCSc : ContentPage
    {
        private MediaFile _mediaFile;
        public PostCSc()
        {
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
            var assembly = typeof(PostCSc);
            cameraIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.cameraA.png", assembly);
        }

        private async void Uploadfile_Tapped(object sender, EventArgs e)
        {
            
            /* 
              {
                  await CrossMedia.Current.Initialize();

                  if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                  {
                      await DisplayAlert("No Camera", ":( No camera available.", "OK");
                      return;
                  }

                  var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                  {
                      Directory = "Sample",
                      Name = "test.jpg"
                  });

                  if (file == null)
                      return;

                  await DisplayAlert("File Location", file.Path, "OK");

                  EventImage.Source = ImageSource.FromStream(() =>
                  {
                      var stream = file.GetStream();
                      return stream;
                  });
              };*/

            
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("No PickPhoto", ":( No PickPhoto available.", "OK");
                    return;
                }

                _mediaFile = await CrossMedia.Current.PickPhotoAsync();

                if (_mediaFile == null)
                    return;

                EventImage.Source = ImageSource.FromStream(() =>
                  {
                      return _mediaFile.GetStream();
                  });
            

        }

        private async void PublishBtn_Clicked(object sender, EventArgs e)
        {

           var imageArray= HelperFile.ReadFully(_mediaFile.GetStream());
            _mediaFile.Dispose();

            var eventN = new PostEvent_N()
            {
                Information = EntInfo.Text,
                PublisherName = EntPublishName.Text,
                Title=EntTitle.Text,
                ImageArray=imageArray
            };
            ApiServices apiServices = new ApiServices();
          bool response= await apiServices.PublishEventN(eventN);
            if (!response)
            {
               await DisplayAlert("Alert", "Something Wrong","Cancel");
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