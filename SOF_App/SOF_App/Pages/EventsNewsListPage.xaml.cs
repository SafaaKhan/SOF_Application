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
    public partial class EventsNewsListPage : ContentPage
    {
        public ObservableCollection<PostEvent_N> postEvent_N;


        public EventsNewsListPage()
        {
            InitializeComponent();
            postEvent_N = new ObservableCollection<PostEvent_N>();
            EventNListGet();
        }

        private async void EventNListGet()
        {

            ApiServices apiServices = new ApiServices();
            var eventNLs= await apiServices.GetEventsN();
            foreach (var eventNL in eventNLs)
            {
                postEvent_N.Add(eventNL);
            }

            LVEventN.ItemsSource = postEvent_N;
        }
    }
}