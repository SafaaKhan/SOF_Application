using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
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
    public partial class NormalStudents : ContentPage
    {
        private FileData _mediaFile;
        private String FileBase64;
        private String FileExtension;
        public NormalStudents()
        {
            InitializeComponent();
            pkGraduatedORContinuing.SelectedIndex = 0;
            student();
        }
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        
        //}

            public async void student()
        {
           // await Navigation.PushAsync(new StudentServices());
        }
        private void CotinueOnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (EntContinuingSt.SelectedItem.ToString() == "Other TransAction")
                stkOtherC.IsVisible = true;
            else
                stkOtherC.IsVisible = false;
        }

        private void GraduateOnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (EntGraduateSt.SelectedItem.ToString() == "Other TransAction")
                stkOtherG.IsVisible = true;
            else
                stkOtherG.IsVisible = false;
        }
        //file choose from device    
        async void btnSelectFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                string[] fileTypes = null;

                if (Device.RuntimePlatform == Device.Android)
                {
                    fileTypes = new string[] { "image/png", "image/jpeg" };
                }

                if (Device.RuntimePlatform == Device.iOS)
                {
                    fileTypes = new string[] { "public.image" }; // same as iOS constant UTType.Image
                }

                if (Device.RuntimePlatform == Device.UWP)
                {
                    fileTypes = new string[] { ".jpg", ".png" };
                }
                _mediaFile = await CrossFilePicker.Current.PickFile(fileTypes);
                if (_mediaFile == null) return;
                string fileName = _mediaFile.FileName;
                FileName.Text = fileName;
                string contents = System.Text.Encoding.UTF8.GetString(_mediaFile.DataArray);
                FileExtension = _mediaFile.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ? ".jpg" : ".png";
                FileBase64 = Convert.ToBase64String(_mediaFile.DataArray);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }

        private async void Send_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pkGraduatedORContinuing.SelectedItem.ToString() == "Graduate Student")
                {
                    if (String.IsNullOrEmpty(EntIdG.Text))
                    {
                        await DisplayAlert(" ", "Please enter The ID", "OK");
                        return;
                    }
                    if (String.IsNullOrEmpty(EntNameG.Text))
                    {
                        await DisplayAlert(" ", "Please enter The Name", "OK");
                        return;
                    }
                    if (String.IsNullOrEmpty(EntEmailG.Text))
                    {
                        await DisplayAlert(" ", "Please enter The Email", "OK");
                        return;
                    }
                    if (String.IsNullOrEmpty(lbGraduate.Text))
                    {
                        await DisplayAlert(" ", "Please enter The Graduate", "OK");
                        return;
                    }
                    if (EntGraduateSt.SelectedItem.ToString() == "Other TransAction")
                        if (String.IsNullOrEmpty(EntGraduateTransaction.Text))
                        {
                            await DisplayAlert(" ", "Please enter The Graduate Transaction", "OK");
                            return;
                        }
                }
                else
                {
                    if (String.IsNullOrEmpty(EntIdC.Text))
                    {
                        await DisplayAlert(" ", "Please enter The ID", "OK");
                        return;
                    }
                    if (String.IsNullOrEmpty(EntNameC.Text))
                    {
                        await DisplayAlert(" ", "Please enter The Name", "OK");
                        return;
                    }
                    if (String.IsNullOrEmpty(EntEmailC.Text))
                    {
                        await DisplayAlert(" ", "Please enter The Email", "OK");
                        return;
                    }
                    if (String.IsNullOrEmpty(lbContinuing.Text))
                    {
                        await DisplayAlert(" ", "Please enter The Continuing", "OK");
                        return;
                    }
                    if (String.IsNullOrEmpty(MajorC.Text))
                    {
                        await DisplayAlert(" ", "Please enter The Major", "OK");
                        return;
                    }
                    if (EntContinuingSt.SelectedItem.ToString() == "Other TransAction")
                    {
                        if (String.IsNullOrEmpty(EntcontinuosTransaction.Text))
                        {
                            await DisplayAlert(" ", "Please enter The continuos Transaction", "OK");
                            return;
                        }
                    }
                }
                if (String.IsNullOrEmpty(FileBase64))
                {
                    await DisplayAlert(" ", "Please Select Photo", "OK");
                    return;
                }
                NormalTransaction objPost;
                if (pkGraduatedORContinuing.SelectedItem.ToString() == "Graduate Student")
                {
                    objPost = new NormalTransaction
                    {
                        GraduatedORContinuing = pkGraduatedORContinuing.SelectedItem.ToString(),
                        EntContinuingSt = "",
                        EntGraduateSt = EntGraduateSt.SelectedItem.ToString(),
                        EntIdC = "",
                        EntIdG = EntIdG.Text,
                        EntNameG = EntNameG.Text,
                        EntNameC = "",
                        EntEmailC = "",
                        MajorC = "",
                        EntEmailG = EntEmailG.Text,
                        lbContinuing = "",
                        lbGraduate = lbGraduate.Text,
                        FilePath = FileBase64,
                        EntcontinuosTransaction = "",
                        EntGraduateTransaction = EntGraduateTransaction.Text ?? "",
                        Status = 0,
                        FileExtension = FileExtension
                    };
                }
                else
                {
                    objPost = new NormalTransaction
                    {
                        GraduatedORContinuing = pkGraduatedORContinuing.SelectedItem.ToString(),
                        EntContinuingSt = EntContinuingSt.SelectedItem.ToString(),
                        EntGraduateSt = "",
                        EntIdC = EntIdC.Text,
                        EntIdG = "",
                        EntNameG = "",
                        EntNameC = EntNameC.Text,
                        EntEmailC = EntEmailC.Text,
                        EntEmailG = "",
                        MajorC = MajorC.Text,
                        lbContinuing = lbContinuing.Text,
                        lbGraduate = "",
                        FilePath = FileBase64,
                        EntcontinuosTransaction = EntcontinuosTransaction.Text ?? "",
                        EntGraduateTransaction = "",
                        Status = 0,
                        FileExtension = FileExtension
                    };
                }

                var postResult = await ApiServices.PostAsync<int>(App.UrlPath + "api/NormalTransactions/PostNormalTransaction", objPost);

                await DisplayAlert(" ", "Request number: " + postResult, "ok");
                await Navigation.PopAsync();
              

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", "There is incorrect or incomplete information ..", "Cancel");
            }
        }

        private void Send_Clicked_1(object sender, EventArgs e)
        {

        }


        private void pkGraduatedORContinuing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pkGraduatedORContinuing.SelectedItem.ToString() == "Graduate Student")
            {
                stkContinuing.IsVisible = false;
                stkGraduate.IsVisible = true;
            }
            else if (pkGraduatedORContinuing.SelectedItem.ToString() == "Continuing Student")
            {
                stkContinuing.IsVisible = true;
                stkGraduate.IsVisible = false;
            }
        }
    }
}