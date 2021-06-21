using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.FilePicker;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.FilePicker.Abstractions;
using SOF_App.Models;
using SOF_App.Services;

namespace SOF_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationForm : ContentPage
    {
        private FileData _mediaFile;
        private string URL { get; set; }
        private String FileBase64;
        protected override async void OnAppearing()
        {
            base.OnAppearing();
           // await Navigation.PushAsync(new Admission_Officer());
        }
        public ApplicationForm()
        {
            InitializeComponent();
        }
        //file choose from device    
        async void btnSelectFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                _mediaFile = await CrossFilePicker.Current.PickFile();
                if (_mediaFile == null) return;
                string fileName = _mediaFile.FileName;
                FileName.Text = fileName;
                string contents = System.Text.Encoding.UTF8.GetString(_mediaFile.DataArray);
                FileBase64 = Convert.ToBase64String(_mediaFile.DataArray);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }

        //async void btnSelectFile_Clicked(object sender, EventArgs e)

        //{
        //    var file = await CrossFilePicker.Current.PickFile();
        //    // file ready
        //}


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
            //var picker = (Picker)sender;
            //int selectedIndex = picker.SelectedIndex;

            //if (selectedIndex != -1)
            if (EntProgram.SelectedItem != null)
            {
                EntProgram.Title = EntProgram.SelectedItem.ToString();
                if (EntProgram.SelectedIndex == 0)
                {
                    EntTrack.ItemsSource = new List<String> { " Infomation Technology ", "Web Development Track", " Net Working and Security Track", "Computing With Business Track ", "Computer Science Track" };
                }
                if (EntProgram.SelectedIndex == 1)
                {
                    EntTrack.ItemsSource = new List<String> { "Marketing Track ", "Accounting Track", " Systems Track" };
                }
                if (EntProgram.SelectedIndex == 2)
                {
                    EntTrack.ItemsSource = new List<String> { "English Language and Literature Track " };
                }
                EntTrack.SelectedIndex = 0;
            }


            //if (picker.SelectedItem == "Other")
            //    entOther.isvisible = true;
            //else
            //    entOther.isvisible = false;
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
            Console.Write("I Confirm the above information are accurate and true");
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

        private async void OnButtonClicked(object sender, EventArgs args)

        {
            try
            {
                if (String.IsNullOrEmpty(EntArea.Text))
                {
                    await DisplayAlert(" ", "Please enter area", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntAverage.Text))
                {
                    await DisplayAlert(" ", "Please enter Average", "OK");
                    return;
                }
                if (EntCertificateType.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please Select High School Certificate Type", "OK");
                    return;
                }
                if (radioGroup.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please Select type of High School ", "OK");
                    return;
                }
                if (FirstradioGroup.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please Select Gender", "OK");
                    return;
                }
                if (secondradioGroup.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please Select the Birth year", "OK");
                    return;
                }
                if (EntSemesters.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please Select Semester", "OK");
                    return;
                }
                if (EntCenter.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please Select Center", "OK");
                    return;
                }
                if (EntIDType.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please Select ID Type", "OK");
                    return;
                }
                if (EntEnglishLevel.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please Select English Level", "OK");
                    return;
                }
                if (EntProgram.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please Select Program", "OK");
                    return;
                }
                if (EntKnowingOfAOU.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please Select Knowing of aou", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntArabicFamily.Text))
                {
                    await DisplayAlert(" ", "Please enter First Name in arabic", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntArabicSecond.Text))
                {
                    await DisplayAlert(" ", "Please enter Second Name in arabic", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntArabicThird.Text))
                {
                    await DisplayAlert(" ", "Please enter Third Name in arabic", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntArabicFamily.Text))
                {
                    await DisplayAlert(" ", "Please enter Family Name in arabic", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntEnglishName.Text))
                {
                    await DisplayAlert(" ", "Please enter First Name in English", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntEnglishSecond.Text))
                {
                    await DisplayAlert(" ", "Please enter Second Name in English", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntEnglishThird.Text))
                {
                    await DisplayAlert(" ", "Please enter Tird Name in English", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntEnglishFamily.Text))
                {
                    await DisplayAlert(" ", "Please enter Family Name in English", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntEmail.Text))
                {
                    await DisplayAlert(" ", "Please enter Email", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntContactName.Text))
                {
                    await DisplayAlert(" ", "Please enter Contact Name", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntArBuilding.Text))
                {
                    await DisplayAlert(" ", "Please enter Building in Arabic", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntArFloor.Text))
                {
                    await DisplayAlert(" ", "Please enter Floor in Arabic", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntArStreet.Text))
                {
                    await DisplayAlert(" ", "Please enter Street in Arabic ", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntBirthDay.Text))
                {
                    await DisplayAlert(" ", "Please enter BirthDay", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntBirthPlace.Text))
                {
                    await DisplayAlert(" ", "Please enter BirthDay Place ", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntCity.Text))
                {
                    await DisplayAlert(" ", "Please enter The City", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntCivilID.Text))
                {
                    await DisplayAlert(" ", "Please enter Civil ID", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntCountry.Text))
                {
                    await DisplayAlert(" ", "Please enter The Country", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntEXPDateID.Text))
                {
                    await DisplayAlert(" ", "Please enter The expire date of ID Card", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntGraduateYear.Text))
                {
                    await DisplayAlert(" ", "Please enter Graduation Year", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntMobileNum.Text))
                {
                    await DisplayAlert(" ", "Please enter Mobile Number", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntPhoneNumEm.Text))
                {
                    await DisplayAlert(" ", "Please enter Emergency Telephon Number ", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(EntPhoneNumH.Text))
                {
                    await DisplayAlert(" ", "Please enter Home Phone Number", "OK");
                    return;
                }
                if (EntTrack.SelectedItem == null)
                {
                    await DisplayAlert(" ", "Please enter Track", "OK");
                    return;
                }
                if (String.IsNullOrEmpty(FileBase64))
                {
                    await DisplayAlert(" ", "Please Upload file", "OK");
                    return;
                }

                FormModel objPost = new FormModel
                {
                    EntArea = EntArea.Text,
                    EntAverage = EntAverage.Text,
                    EntArBuilding = EntArBuilding.Text,
                    EntEnBuilding = EntEnBuilding.Text,
                    EntArtSience = radioGroup.SelectedItem as String == "High School in Art/Sience" ? "True" : "False",
                    EntCity = EntCity.Text,
                    EntCivilID = EntCivilID.Text,
                    EntContactName = EntContactName.Text,
                    EntCountry = EntCountry.Text,
                    EntBirthDay = EntBirthDay.Text,
                    EntHijri = secondradioGroup.SelectedItem as String == "Hijri" ? "True" : "False",
                    EntEXPDateID = EntEXPDateID.Text,
                    EntHaveAjob = EntHaveAjob.IsChecked.ToString(),
                    EntEnglishLevel = EntEnglishLevel.SelectedItem as String,
                    EntCuorses = radioGroup.SelectedItem as String == "Cuorses" ? "True" : "False",
                    EntMale = FirstradioGroup.SelectedItem as String == "Male" ? "True" : "False",
                    EntArabicFamily = EntArabicFamily.Text,
                    EntEnglishFamily = EntEnglishFamily.Text,
                    EntArabicName = EntArabicName.Text,
                    EntEnglishName = EntEnglishName.Text,
                    EntArFloor = EntArFloor.Text,
                    EntEnFloor = EntEnFloor.Text,
                    EntFemale = FirstradioGroup.SelectedItem as String,//== EntMale.Text ? "True" : "False",
                    EntGraduateYear = EntGraduateYear.Text,
                    EntTofelTest = EntTofelTest.IsChecked.ToString(),
                    EntPhoneNumH = EntPhoneNumH.Text,
                    EntIDType = EntIDType.SelectedItem as String,
                    EntHaveDisAbility = EntHaveDisAbility.IsChecked.ToString(),
                    EntKnowingOfAOU = EntKnowingOfAOU.SelectedItem.ToString(),
                    EntMobileNum = EntMobileNum.Text,
                    EntNationality = EntNationality.Text,
                    EntEmail = EntEmail.Text,
                    EntPhoneNumEm = EntPhoneNumEm.Text,
                    EntBirthPlace = EntBirthPlace.Text,
                    EntProgram = EntProgram.SelectedItem.ToString(),
                    EntQyasGrade = EntQyasGrade.Text,
                    EntArabicSecond = EntArabicSecond.Text,
                    EntEnglishSecond = EntEnglishSecond.Text,
                    EntSemesters = EntSemesters.SelectedItem.ToString(),
                    EntArStreet = EntArStreet.Text,
                    EntEnStreet = EntEnStreet.Text,
                    EntArabicThird = EntArabicThird.Text,
                    EntEnglishThird = EntEnglishThird.Text,
                    EntTrack = EntTrack.SelectedItem.ToString(),
                    EntCenter = EntCenter.SelectedItem.ToString(),
                    EntCertificateType = EntCertificateType.SelectedItem as String,
                    EntGregorian = secondradioGroup.SelectedItem as String == "Gregorian" ? "True" : "False",
                    FilePath = FileBase64

                };
                //FormModel objPost = new FormModel
                //{
                //    EntArea = "Area",
                //    EntAverage = "50",
                //    EntArBuilding = "1",
                //    EntEnBuilding = "1",
                //    EntArtSience = "scientific",
                //    EntCity = "Riadh",
                //    EntCivilID = "civil 1",
                //    EntContactName = "Yamam",
                //    EntCountry = "Country",
                //    EntBirthDay = "24",
                //    EntHijri = "Ba3rafesh",
                //    EntEXPDateID = "5000",
                //    EntHaveAjob = "True",
                //    EntEnglishLevel = "Advanced",
                //    EntCuorses = "True",
                //    EntMale = "False",
                //    EntArabicFamily = "Ahmad",
                //    EntEnglishFamily = "Ahmad",
                //    EntArabicName = "Yamam",
                //    EntEnglishName = "Yamam",
                //    EntArFloor = "Floor",
                //    EntEnFloor = "Floor",
                //    EntFemale = "Female",
                //    EntGraduateYear = "2020",
                //    EntTofelTest = "True",
                //    EntPhoneNumH = "009661234567",
                //    EntIDType = "Eqamah",
                //    EntHaveDisAbility = "True",
                //    EntKnowingOfAOU = "True",
                //    EntMobileNum = "009661234567",
                //    EntNationality = "Syrian",
                //    EntEmail = "Yamam@gmail.com",
                //    EntPhoneNumEm = "009661234567",
                //    EntBirthPlace = "Saudia Arabia",
                //    EntProgram = "Information Technology And Computing",
                //    EntQyasGrade = "1000",
                //    EntArabicSecond = "Ahmed",
                //    EntEnglishSecond = "Ahmed",
                //    EntSemesters = "Second 2019-2020",
                //    EntArStreet = "Street",
                //    EntEnStreet = "Street",
                //    EntArabicThird = "Ahmed",
                //    EntEnglishThird = "Ahmed",
                //    EntTrack = "Track",
                //    EntCenter = "Ryadh",
                //    EntGregorian = "gre",
                //    EntCertificateType = "Type"
                //};
                var postResult = await ApiServices.PostAsync<int>(App.UrlPath + "api/RegistrationForms/Post", objPost);
                await DisplayAlert(" ", "Form ID : " + postResult, "ok");
                Navigation.InsertPageBefore(new RulesAndRequirments(), this);
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", "There is incorrect or incomplete information ..", "Cancel");
                //await DisplayAlert("Error", ex.Message, "ok");
            }

        }

        private void confirmed_CheckChanged(object sender, EventArgs e)
        {
            if (confirmed.IsChecked)
                btnSubmit.IsEnabled = true;
            else
                btnSubmit.IsEnabled = false;

        }
    }
}