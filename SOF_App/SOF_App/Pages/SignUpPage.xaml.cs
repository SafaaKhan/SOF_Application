using SOF_App.Models;
using SOF_App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOF_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        string memberType = FirstPage.membertype;
        string serviceChoose;
        string departmentChoose;
        public ObservableCollection<Department> departments;
        public List<string> _dep;

        public SignUpPage()
        {
            InitializeComponent();
            departments = new ObservableCollection<Department>();
            _dep = new List<string>();
    

            if (memberType == "Adminstrator" )
            {
                ServicesPicker.IsVisible=true;
                

               // DepartmentPicker.IsVisible = true;


            }
            else if(memberType == "Academic")
            {
                DepartmentPicker.IsVisible = true;

                DepartmentGet();
                DepartmentPicker.IsEnabled = true;
            }

        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {



            ApiServices apiservice = new ApiServices();

            if (memberType == "club")
            {
                bool response = await apiservice.RegisterUser(EntName.Text, EntID.Text, EntPassword.Text, EntConfirmPassword.Text, EntEmail.Text, memberType, "_", "_");
                if (!response)
                {
                    // if(apiServices.RegisterUser.EntEmail.)
                    await DisplayAlert("Alert!", "Something wrong...", "Cancel");
                }
                else
                {
                    await DisplayAlert("Hi", "Your account has been created ", "Alright");
                    await Navigation.PopToRootAsync();
                }
            }
            else if (memberType == "Normal Student")
            {
                bool response = await apiservice.RegisterUser(EntName.Text, EntID.Text, EntPassword.Text, EntConfirmPassword.Text, EntEmail.Text, memberType, "_", "_");
                if (!response)
                {
                    // if(apiServices.RegisterUser.EntEmail.)
                    await DisplayAlert("Alert!", "Something wrong...", "Cancel");
                }
                else
                {
                    await DisplayAlert("Hi", "Your account has been created ", "Alright");
                    await Navigation.PopToRootAsync();
                }
            }

            else if (memberType == "Adminstrator" || memberType == "Academic")
            {
                if (serEnt.IsVisible)
                {
                    serviceChoose = serEnt.Text;
                }
                bool response = false;
                if (memberType == "Adminstrator")
                {
                    response = await apiservice.RegisterUser(EntName.Text, EntID.Text, EntPassword.Text, EntConfirmPassword.Text, EntEmail.Text, memberType, serviceChoose, "-");
                }
                else
                {
                    response = await apiservice.RegisterUser(EntName.Text,EntID.Text, EntPassword.Text, EntConfirmPassword.Text, EntEmail.Text, memberType, "_", departmentChoose);
                }


                //check _reponse
                if (!response)
                {
                    // if(apiServices.RegisterUser.EntEmail.)
                    await DisplayAlert("Alert!", "Something wrong...", "Cancel");
                }
                else
                {
                    await DisplayAlert("Hi", "Your account has been created ", "Alright");
                    await Navigation.PopToRootAsync();
                }
            }

            else if (memberType == "security")
            {
                bool response = await apiservice.RegisterUser(EntName.Text, EntID.Text, EntPassword.Text, EntConfirmPassword.Text, EntEmail.Text, memberType, "_", "_");
                if (!response)
                {
                    // if(apiServices.RegisterUser.EntEmail.)
                    await DisplayAlert("Alert!", "Something wrong...", "Cancel");
                }
                else
                {
                    await DisplayAlert("Hi", "Your account has been created ", "Alright");
                    await Navigation.PopToRootAsync();
                }
            }


        }



        private void ServicesPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string service;
            if (selectedItem != null)
            {
                service = (string)selectedItem;
                serviceChoose = service;
                if (service == "Other")
                {
                    serLbl.IsVisible = true;
                    serEnt.IsVisible = true;
                    serLbl.IsEnabled = true;
                    serEnt.IsEnabled = true;
                  //  serviceChoose = serEnt.Text;//////////check
                }
              /*  else if (serviceChoose == "Academic Guidance")
                {
                  
                    {
                        DepartmentGet();
                        DepartmentPicker.IsEnabled = true;
                    }

                }*/

            }
            //  ApiServices apiServices = new ApiServices();
            //  string url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStaffService?staffservice={0}", serviceChoose);
            // bool _reponse = await apiServices.GetStaffService(url);


        }


        private async void DepartmentGet()
        {
            ApiServices apiServices = new ApiServices();
            var _department = await apiServices.GetDepartments();
            foreach (var department in _department)
            {
                departments.Add(department);
            }

            foreach (var department in departments)
            {
                _dep.Add(department.department);
            }
            DepartmentPicker.ItemsSource = _dep;

        }

        private void DepartmentPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string department;
            if (selectedItem != null)
            {
                department = (string)selectedItem;
                departmentChoose = department;

            }
        }
    }
}