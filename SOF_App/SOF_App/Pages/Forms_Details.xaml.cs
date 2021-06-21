using Plugin.FilePicker;
using SOF_App.Models;
using SOF_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOF_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Forms_Details : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await Download_File(_objPost.FilePath);

        }
        FormModel _objPost;
        public Forms_Details(FormModel objPost)
        {
            _objPost = objPost;
            InitializeComponent();

            EntArea.Text = objPost.EntArea;
            EntAverage.Text = objPost.EntAverage;
            EntArBuilding.Text = objPost.EntArBuilding;
            EntEnBuilding.Text = objPost.EntEnBuilding;
            EntCertificateType.SelectedItem = objPost.EntArtSience;// == "True" ? "scientific": "literary";
            EntCity.Text = objPost.EntCity;
            EntCivilID.Text = objPost.EntCivilID;
            EntContactName.Text = objPost.EntContactName;
            EntCountry.Text = objPost.EntCountry;
            EntBirthDay.Text = objPost.EntBirthDay;
            EntBirthDay.Text = objPost.EntHijri;
            EntEXPDateID.Text = objPost.EntEXPDateID;
            EntHaveAjob.IsChecked = objPost.EntHaveAjob == "True";
            EntEnglishLevel.SelectedItem = objPost.EntEnglishLevel;
            radioGroup.SelectedItem = objPost.EntCuorses == "True" ? "High School in Art/Sience" : "Cuorses";
            FirstradioGroup.SelectedItem = objPost.EntMale == "True" ? "Male" : "Female";
            //EntCertificateType.SelectedItem = objPost.EntMale == "True" ? "Male" : "Female";
            EntArabicFamily.Text = objPost.EntArabicFamily;
            EntEnglishFamily.Text = objPost.EntEnglishFamily;
            EntArabicName.Text = objPost.EntArabicName;
            EntEnglishName.Text = objPost.EntEnglishName;
            EntArFloor.Text = objPost.EntArFloor;
            EntEnFloor.Text = objPost.EntEnFloor;
            //FirstradioGroup.SelectedItem == objPost.EntFemale "True" : "False",
            EntGraduateYear.Text = objPost.EntGraduateYear;
            EntTofelTest.IsChecked = objPost.EntTofelTest == "True";
            EntPhoneNumH.Text = objPost.EntPhoneNumH;
            EntIDType.SelectedItem = objPost.EntIDType;
            EntHaveDisAbility.IsChecked = objPost.EntHaveDisAbility == "True";
            EntKnowingOfAOU.SelectedItem = objPost.EntKnowingOfAOU;
            EntMobileNum.Text = objPost.EntMobileNum;
            EntNationality.Text = objPost.EntNationality;
            EntEmail.Text = objPost.EntEmail;
            EntPhoneNumEm.Text = objPost.EntPhoneNumEm;
            EntBirthPlace.Text = objPost.EntBirthPlace;
            EntProgram.SelectedItem = objPost.EntProgram;
            EntQyasGrade.Text = objPost.EntQyasGrade;
            EntArabicSecond.Text = objPost.EntArabicSecond;
            EntEnglishSecond.Text = objPost.EntEnglishSecond;
            EntSemesters.SelectedItem = objPost.EntSemesters;
            EntArStreet.Text = objPost.EntArStreet;
            EntEnStreet.Text = objPost.EntEnStreet;
            EntArabicThird.Text = objPost.EntArabicThird;
            EntEnglishThird.Text = objPost.EntEnglishThird;
            EntTrack.Text = objPost.EntTrack;
            EntCenter.SelectedItem = objPost.EntCenter;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await Launcher.CanOpenAsync(new Uri(App.UrlPath + "Files/" + _objPost.FilePath)))
                await Launcher.OpenAsync(new Uri(App.UrlPath + "Files/" + _objPost.FilePath));
            //DependencyService.Get<IPathService>().OpenPdfFile(_objPost.FilePath);
        }


        //public async Task<String> Download_File(String FileName)
        //{
        //    try
        //    {
        //        Device.OpenUri(new Uri(App.UrlPath+"Files/"+FileName));
        //        var File = await ApiServices.PostAsync<Byte[]>(App.UrlPath + "api/registrationform/GetFile", new FileHelper { FilePath = FileName});
        //        var externalPath = DependencyService.Get<IPathService>().PublicExternalFolder + "/YamamFiles";
        //        DependencyService.Get<IPathService>().CheckDir(externalPath);
        //        string dbPath = System.IO.Path.Combine(externalPath, FileName );
        //        var stream = new MemoryStream(File);
        //        using (var br = new BinaryReader(stream))
        //        { 
        //            System.IO.File.WriteAllBytes(dbPath, File);
        //            //using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
        //            //{
        //            //    byte[] buffer = new byte[2048];
        //            //    int length = 0;
        //            //    while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
        //            //    {
        //            //        bw.Write(buffer, 0, length);
        //            //    }
        //            //}
        //        }
        //        return "OK";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}


        async void btnSelectFile_Clicked(object sender, EventArgs e)

        {
            var file = await CrossFilePicker.Current.PickFile();
            // file ready
        }


        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                EntSemesters.Title = (string)picker.ItemsSource[selectedIndex];
            }

        }
        void CeOnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                EntCenter.Title = (string)picker.ItemsSource[selectedIndex];
            }
        }
        void IDOnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                EntIDType.Title = (string)picker.ItemsSource[selectedIndex];
            }
        }
        void CerOnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                EntCertificateType.Title = (string)picker.ItemsSource[selectedIndex];
            }
        }
        void EnOnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                EntEnglishLevel.Title = (string)picker.ItemsSource[selectedIndex];
            }
        }
        void PrOnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                EntProgram.Title = (string)picker.ItemsSource[selectedIndex];
            }
        }
        void KnOnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                EntKnowingOfAOU.Title = (string)picker.ItemsSource[selectedIndex];
            }

        }
        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                EntProgram.Title = (string)picker.ItemsSource[selectedIndex];
            }
        }


        void tofelOnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Console.Write("Have you taken Tofel test ?");
        }
        void JopOnCheckBoxCheckedChanged(object HaveAjob, CheckedChangedEventArgs e)
        {
            Console.Write("Do you currently have any job ?");
        }
        void DisOnCheckBoxCheckedChanged(object HaveDisAbility, CheckedChangedEventArgs e)
        {
            Console.Write("If you have any kind of disability,pleasr specify ?");
        }
        void ConfirmOnCheckBoxCheckedChanged(object confirmed, CheckedChangedEventArgs e)
        {
            Console.Write("I confirm the above information are accurate and true");
        }


        private void EntMale_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void EntFemale_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void EntGregorian_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void EntHijri_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void EntArtSience_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void EntCuorses_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var sen = sender as Button;
            var hh = _objPost;
            var res = await ApiServices.GetAsync<int>(String.Format(App.UrlPath + "api/RegistrationForms/ChangeStatus?FormID={0}&Status={1}&email={2}", hh.ID, sen.ClassId, hh.EntEmail));
            if (res == 1)
            {
                await DisplayAlert(" ", "Done", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}