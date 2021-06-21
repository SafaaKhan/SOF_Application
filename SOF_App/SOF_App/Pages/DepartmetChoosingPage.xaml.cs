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
    public partial class DepartmetChoosingPage : ContentPage
    {
        public ObservableCollection<Department> departments;
        public List<string> _dep;

        public DepartmetChoosingPage()
        {
            InitializeComponent();
            var assembly = typeof(LostThingDetails);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            departments = new ObservableCollection<Department>();
            _dep = new List<string>();
            DepartmentGet();
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
                _dep.Add( department.department);
            }
            DepartmentPicker.ItemsSource = _dep;

        }



        public static string departmentType;
        private void DepartmentPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        
            var picker = (Picker)sender;
            var selectedItem = picker.SelectedItem;
            string department;
            if (selectedItem != null)
            {
                department = (string)selectedItem;
                departmentType = department;
                Navigation.PushAsync(new StuffChoosingPage());
                /* department = (string)selectedItem;
                 if (department == "Information Technology(IT)")
                 {
                     departmentType = department;
                     Navigation.PushAsync(new StuffChoosingPage());

                 */
                /*   else if (department == "Booking Book")
                   {

                   */
            }
            ((Picker)sender).SelectedItem = null;
        }
    }
}