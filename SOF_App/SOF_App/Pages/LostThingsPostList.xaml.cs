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
    public partial class LostThingsPostList : ContentPage
    {

        public ObservableCollection<LostThingsPostModel> lostThingsPosts;

        public LostThingsPostList()
        {
            InitializeComponent();
            lostThingsPosts = new ObservableCollection<LostThingsPostModel>();
            LostThingsGet();
        }

       
        private async void LostThingsGet()
        {
            ApiServices apiServices = new ApiServices();
            var _LostThings = await apiServices.GetLostThing();
            foreach(var _lostThing in _LostThings)
            {
                lostThingsPosts.Add(_lostThing);
            }

            LVLostThings.ItemsSource = _LostThings;
        }

        private void LVLostThings_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           var selsectedThing=  e.SelectedItem as LostThingsPostModel;
            if(selsectedThing != null)
            {
                Navigation.PushAsync(new LostThingDetails(selsectedThing));
            }
           
            ((ListView)sender).SelectedItem = null;
        }
    }
}
 