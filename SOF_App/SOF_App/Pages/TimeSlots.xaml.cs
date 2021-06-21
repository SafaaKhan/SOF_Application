using DocumentFormat.OpenXml.EMMA;
using Foundation;
using SOF_App.Models;
using SOF_App.Services;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

namespace SOF_App.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class TimeSlots : ContentPage
    {
        string _staffName = StuffChoosingPage.staffName;
        string serviceType;
        string serviceTyoeOther=NormalStusentPage.servicetype;
        bool adminstratorMember = NormalStusentPage.adminstratorMember;
        //aadd
        string AdacemicService = AdditionalStaffServices.staffService;
        string _studentID1 = App.studentID;
        string _studentID2 = SignInPage.studentID;
        string _studentID;
       // string DateType;//from the insertDateclass
        DateTime startDate;
        DateTime endDate;
        public ObservableCollection<TimeSlot> timeSlots;
        public ObservableCollection<string> dateInfullDate;
        public ObservableCollection<FullDates> fullDates; List<string> _timeSlots;
      public ObservableCollection<StudentReservedAppointment> studentReservedAppointments;
       static public ObservableCollection<TimeSlotDiv> timeSlotDivs;
        public TimeSlots()
        {
            InitializeComponent();
           if(_studentID1 == null)
            {
                _studentID = _studentID2;
            }
            else
            {
                _studentID = _studentID1;
            }


           if(serviceTyoeOther == "Academic Services" )
            {
                serviceType = AdacemicService;
            }
            else
            {
                serviceType = serviceTyoeOther;
            }//delete
         
            timeSlots = new ObservableCollection<TimeSlot>();
           studentReservedAppointments = new ObservableCollection<StudentReservedAppointment>();
            timeSlotDivs = new ObservableCollection<TimeSlotDiv>();
            fullDates = new ObservableCollection<FullDates>();
            dateInfullDate = new ObservableCollection<string>();
            //  GetTimeSlots();
            GetDates();




            //staff
            //admin
            //??
            //for academic_ depending on the sevice_choosing service==service the staff chosed
           
            
        }


         DateTime disableStartDate;
         DateTime disableEndDate;
         bool disablestatus;
         string disableMSG;
        string dayType = "";
        List<TimeSlot> timeSlotInfo;
        List<string> days = new List<string>();
        bool stopcond = true;
        public async void GetDates()
           
        {//try catch
           
        
            string service = AdditionalStaffServices.staffService;
            ApiServices apiServices = new ApiServices();
            if(adminstratorMember== true)
            {
                timeSlotInfo = await apiServices.GetTimeSlotInfo(_staffName, serviceType);
            }
            else
            {
                timeSlotInfo = await apiServices.GetTimeSlotInfo(_staffName, service);
            }
           
            if(timeSlotInfo.Count == 1)
            {
                foreach (var timeslot in timeSlotInfo)
                {
                    startDate = timeslot.startDate;
                    endDate = timeslot.endDate;
                    dayType = timeslot.WorkingDaysTupe;
                    if (dayType == "Specific Days")
                    {
                        days.Add(timeslot.Day);
                    }
                    if (timeslot.disablestatus == true)
                    {
                        if (stopcond == true)
                        {
                            stopcond = false;
                            disableStartDate = timeslot.disableStartDate;
                            disableEndDate = timeslot.disableEndDate;
                            disableMSG = timeslot.disableMSG;
                            disablestatus = timeslot.disablestatus;
                        }
                    }
                }
            }
            else if (timeSlotInfo.Count > 1)
            {
                foreach (var timeslot in timeSlotInfo)
                {
                    startDate = timeslot.startDate;
                    endDate = timeslot.endDate;
                    dayType = timeslot.WorkingDaysTupe;
                    if (dayType == "Specific Days")
                    {
                        days.Add(timeslot.Day);
                    }
                    if (timeslot.disablestatus == true)
                    {
                        disableStartDate = timeslot.disableStartDate;
                        disableEndDate = timeslot.disableEndDate;
                        disableMSG = timeslot.disableMSG;
                        disablestatus = timeslot.disablestatus;
                    }
                   // for(int i= disableStartDate.)
                }
            }
           
            //admin
             string dt= DateTime.Now.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            if (serviceType == "Academic Guidance" || adminstratorMember==true)//
            {
                calendar.MinDate = DateTime.Now;

                calendar.MaxDate = endDate;

            }

            else
            {
                
                calendar.MinDate = Convert.ToDateTime(startDate);//change according the staff

                calendar.MaxDate = Convert.ToDateTime(endDate);
            }

            //end of semester
            calendar.SelectedDate = null;
            if (disablestatus == true)
            {
                msg_Label.IsVisible = true;
                msgLabel.IsVisible = true;

                msgLabel.Text = disableMSG;
            }
            // calendar.BlackoutDatesViewMode = BlackoutDatesViewMode.Stripes;
            await DisplayAlert("Notic", "Any date with \"X\" mark is disable and you can not choose it", "OK");
        }


        List<DateTime> disableDates = new List<DateTime>();
        public List<DateTime> DisableDates()
        {
            for (DateTime i = disableStartDate; i <= disableEndDate; i = i.AddDays(1))//if was month
            {
                disableDates.Add(i);
            }
            return disableDates;
        }


        MonthViewSettings monthViewSettings = new MonthViewSettings();
        List<DateTime> blackoutDates = new List<DateTime>();
        string dayOfWeek;
        // List<DateTime> dateTimes = new List<DateTime>();
        private async void calendar_OnMonthCellLoaded(object sender, MonthCellLoadedEventArgs e)
        {
            
            dayOfWeek = e.Date.DayOfWeek.ToString();
            // DateTime.DaysInMonth

            //time
            if (dayType == "Specific Days")
            {
                if (dayOfWeek.ToString() == DayOfWeek.Saturday.ToString() || dayOfWeek.ToString() == DayOfWeek.Friday.ToString())
                {
                    blackoutDates.Add(e.Date);


                    List<DateTime> d = await ConvetStringToDateTimeList();
                    foreach (var dd in d)
                    {
                        blackoutDates.Add(dd);
                        
                    }

                    List<DateTime> dateDay = Days();
                    foreach (var date in dateDay)
                    {
                        blackoutDates.Add(date);
                        
                    }

                    if (disablestatus == true)
                    {
                        List<DateTime> _disDates = DisableDates();
                        foreach(var date in _disDates)
                        {
                            blackoutDates.Add(date);
                           
                        }
                    }


                }

            }


            else if (dayOfWeek.ToString() == DayOfWeek.Saturday.ToString() || dayOfWeek.ToString() == DayOfWeek.Friday.ToString())
            {
                blackoutDates.Add(e.Date);

               
                List<DateTime> d = await ConvetStringToDateTimeList();
                foreach (var dd in d)
                {
                    blackoutDates.Add(dd);
                }

                //add here ,then check

                if (disablestatus == true)
                {
                    List<DateTime> _disDates = DisableDates();
                    foreach (var date in _disDates)
                    {
                        blackoutDates.Add(date);
                    }
                }


            }


            calendar.BlackoutDates = blackoutDates;

        }



        public List<DateTime> Days()
        {
          

            DateTime MinimumDate = DateTime.Now;
           List<DateTime> d = new List<DateTime>();
            SpecialDate SpecDate = new SpecialDate(MinimumDate);
            for (DateTime i = startDate; i < endDate.AddMonths(12); i = i.AddDays(1))
            {
                while (!days.Contains(i.DayOfWeek.ToString()))
                {
                    d.Add(i);
                    i = i.AddDays(1);
                }




                //foreach( var day__ in days)
                //{
                //    if (i.DayOfWeek.ToString() != day__)
                //    {
                //        d.Add(i);
                        
                //    }
                //}
                
            }
            return d;
        }




        public async Task<List<DateTime>> ConvetStringToDateTimeList()
        {
            ApiServices apiServices = new ApiServices();

            //get dates in fullDate db
            List<FullDates> __fullDatesStaffName = await apiServices.GetFullDateInfo(_staffName);
            foreach (var date in __fullDatesStaffName)
            {
                dateInfullDate.Add(date.date);
            }
            List<DateTime> dateTimes = new List<DateTime>();
            foreach (var _date in dateInfullDate)
            {
                dateTimes.Add(DateTime.Parse(_date));
            }
            return dateTimes;
        }




        string d;//should be null
        //create database contains all full dates
        int countslots;
        int countApp;
        System.DateTime d_;
        List<TimeSlotDiv> newTimeSlots;
        private async void calendar_OnCalendarTapped(object sender, CalendarTappedEventArgs e)
        {
            d = e.DateTime.ToString();
            countslots = 0;
            countApp = 0;
            d_ = System.DateTime.Parse(d);
            if(dayType == "Specific Days")
            {
                Test_2();
            }
            else
            {
                Test();
            }
           

        }


        public async void Test_2()
        {
           
            LVTimeslot.ItemsSource = "";
            newTimeSlots = new List<TimeSlotDiv>();
            countslots = await GettimeSlotDivs();//make it zero
           // GetSpecificTimeSlot();
            countApp = await GetAppoinmet(d);//all//make in zero after book appoint and choose another date
            if (!blackoutDates.Contains(d_))
            {
                if (countSpecieficDate < countslots)//and the date not in the blockdate list
                {
                    // await DisplayAlert("Hi", "testing ", "OK");//list will be shown
                    //list
                    if (_studentReserverdAppointmentTime.Count() == 0)
                    {
                        foreach (var dbDate in timeSlotDivsTemp)
                        {

                            newTimeSlots.Add(dbDate);



                        }
                    }
                    else
                    {
                        foreach (var dbDate in timeSlotDivsTemp)
                        {
                            foreach (var time in _studentReserverdAppointmentTime)
                            {
                                if (dbDate.time != time)
                                {
                                    newTimeSlots.Add(dbDate);
                                }

                            }
                        }
                    }


                    LVTimeslot.ItemsSource = newTimeSlots;
                    LVTimeslot.IsVisible = true;
                }
                else
                {//have to add the date to full date once it became full
                    ApiServices apiServices = new ApiServices();

                    //get dates in fullDate db
                    /*   List<FullDates> __fullDatesStaffName = await apiServices.GetFullDateInfo(_staffName);
                       foreach (var date in __fullDatesStaffName)
                       {
                           dateInfullDate.Add(date.date);
                       }*/
                    //fullInDate List



                    //if the current d is not in the ddb

                    foreach (string dateDB in dateInfullDate)
                    {
                        if (dateDB != d)
                        {
                            FullDates ___fullDates = new FullDates()
                            {
                                date = d,
                                staffName = _staffName

                            };

                            var response = apiServices.PublishFullDates(___fullDates);
                            break; //test
                        }
                    }
                    //then add it else no
                    //////////////////////////////////////
                    ////after that add the fulldate list to blockdate list
                    ///




                    //if--else--response

                }


            }
            /* else
             {
                 await DisplayAlert("Sorry", "You can not choose this date","OK");
             }*/

            //((ListView)sender).SelectedItem = null;

        }



        public async void Test()
        {

            LVTimeslot.ItemsSource = "";
            newTimeSlots = new List<TimeSlotDiv>();
            countslots = await GettimeSlotDivs();//make it zero
            countApp = await GetAppoinmet(d);//all//make in zero after book appoint and choose another date
            if (!blackoutDates.Contains(d_))
            {
                if (countSpecieficDate < countslots)//and the date not in the blockdate list
                {
                    // await DisplayAlert("Hi", "testing ", "OK");//list will be shown
                    //list
                    if (_studentReserverdAppointmentTime.Count() == 0)
                    {
                        foreach (var dbDate in timeSlotDivs)
                        {

                            newTimeSlots.Add(dbDate);



                        }
                    }
                    else
                    {
                        foreach (var dbDate in timeSlotDivs)
                        {
                            foreach (var time in _studentReserverdAppointmentTime)
                            {
                                if (dbDate.time != time)
                                {
                                    newTimeSlots.Add(dbDate);
                                }

                            }
                        }
                    }


                    LVTimeslot.ItemsSource = newTimeSlots;
                    LVTimeslot.IsVisible = true;
                }
                else
                {//have to add the date to full date once it became full
                    ApiServices apiServices = new ApiServices();

                    //get dates in fullDate db
                    /*   List<FullDates> __fullDatesStaffName = await apiServices.GetFullDateInfo(_staffName);
                       foreach (var date in __fullDatesStaffName)
                       {
                           dateInfullDate.Add(date.date);
                       }*/
                    //fullInDate List



                    //if the current d is not in the ddb

                    foreach (string dateDB in dateInfullDate)
                    {
                        if (dateDB != d)
                        {
                            FullDates ___fullDates = new FullDates()
                            {
                                date = d,
                                staffName = _staffName

                            };

                            var response = apiServices.PublishFullDates(___fullDates);
                            break; //test
                        }
                    }
                    //then add it else no
                    //////////////////////////////////////
                    ////after that add the fulldate list to blockdate list
                    ///




                    //if--else--response

                }


            }
            /* else
             {
                 await DisplayAlert("Sorry", "You can not choose this date","OK");
             }*/

            //((ListView)sender).SelectedItem = null;

        }

        List<TimeSlotDiv> timeSlotDivsTemp = new List<TimeSlotDiv>();

        public int GetSpecificTimeSlot()
        {
            timeSlotDivsTemp = new List<TimeSlotDiv>();
            foreach (var day in timeSlotDivs)
            {
                if(day.Day == dayOfWeek)
                {
                    timeSlotDivsTemp.Add(day);
                }
            }

            return timeSlotDivsTemp.Count();
        }




        public async Task<int> GettimeSlotDivs()
        {
            string service = AdditionalStaffServices.staffService;
            var timeSlotDivsInfo= new List<TimeSlotDiv>();
            ApiServices apiServices = new ApiServices();
            if (adminstratorMember == true)
            {
                 timeSlotDivsInfo = await apiServices.GetTimeSlotDivInfo(_staffName, serviceType);
            }
            else
            {
                 timeSlotDivsInfo = await apiServices.GetTimeSlotDivInfo(_staffName, service);
            }
           

            timeSlotDivs = new ObservableCollection<TimeSlotDiv>();
            foreach (var _timeSlot in timeSlotDivsInfo)
            {
                timeSlotDivs.Add(_timeSlot);
            }
            // LVTimeslot.ItemsSource = newTimeSlots; ;
            if(dayType == "Specific Days")
            {
                int count = GetSpecificTimeSlot();
                return count;
            }
            else
            {
                return timeSlotDivs.Count();
            }
            
            
        }








        static List<string> _studentReserverdAppointmentTime;
        List<string> _date;//db
        int countDateDB;
        int countSpecieficDate = 0;
        public async Task<int> GetAppoinmet(string selectedDate)
        {
            _studentReserverdAppointmentTime = new List<string>();
            _date = new List<string>();

            ApiServices apiServices = new ApiServices();
            var __studentReservedAppointments = await apiServices.GetStudentReservedAppointment(_staffName);

            List<string> _time = new List<string>();
            foreach (var dateTime in __studentReservedAppointments)
            {
                _date.Add(dateTime.Date);
                _time.Add(dateTime.Time);
                if (dateTime.Date == selectedDate)
                {
                    _studentReserverdAppointmentTime.Add(dateTime.Time);
                }
                studentReservedAppointments.Add(dateTime);
            }
            countSpecieficDate = 0;
            foreach (var date_ in _date)
            {
                if (date_ == selectedDate)
                {
                    countSpecieficDate++;
                }
            }
            countDateDB = _date.Count();
            return studentReservedAppointments.Count();
        }

      


        private async void BookBtn_Clicked(object sender, EventArgs e)
        {
            /* var button = (Button)sender;
             StackLayout stackLayout = (StackLayout)button.Parent;
             ListView listView = (ListView)stackLayout.Children[2];*/

            //  string x = lb.Text;


            // string _staffName = _staffName;
           
            StudentReservedAppointment studentReservedAppointment = new StudentReservedAppointment()
            {
                // Date = DateP.Date.ToString(),
                Date = calendar.SelectedDate.ToString(),
                serviceName = serviceType,
                staffName = _staffName,
                studentID = _studentID,
                Time = selectedTime,
                status = _status,
                roleNumber= _rolenumber

            };

            /*var s = (DateTime)calendar.SelectedDate;
            calendar.BlackoutDates.Add(s);*/
            // this.Content = calendar;
            ApiServices apiServices = new ApiServices();
            bool response = await apiServices.PublishStudentReservedAppointment(studentReservedAppointment);

            if (!response)
            {
                await DisplayAlert("Ooops", "Something wrong..", "Alraight");
            }
            else
            {//Confirm
                string message = _studentID+" has booked an appoitment at\n " + selectedTime + " at date " + calendar.SelectedDate.ToString().Substring(0, calendar.SelectedDate.ToString().Length - 11) + "\n" + " in "+ serviceType+ " Your role number: " + _rolenumber;
                await DisplayAlert("Hi", message, "OK");
                List<string> email = new List<string>();
                email.Add("Safa3.1998@hotmail.com");
                SendEmail();//?

               // LVTimeslot.IsVisible = false;
                countSpecieficDate++;
               AddInBlackOutDates();
                if(dayType == "Specific Days")
                {
                    Test_2();
                }
                else
                {
                    Test();
                }
               
            

            }


        }

        public void AddInBlackOutDates()
        {
            if (!blackoutDates.Contains(d_))
            {
                if (countSpecieficDate >= countslots)//and the date not in the blockdate list
                {
                    ApiServices apiServices = new ApiServices();
                    if (dateInfullDate.Count == 0)
                    {
                        FullDates ___fullDates = new FullDates()
                        {
                            date = d,
                            staffName = _staffName

                        };

                        var response = apiServices.PublishFullDates(___fullDates);
                        
                    }
                    else
                    {
                        foreach (string dateDB in dateInfullDate)//check later
                        {
                            if (dateDB != d)
                            {
                                FullDates ___fullDates = new FullDates()
                                {
                                    date = d,
                                    staffName = _staffName

                                };

                                var response = apiServices.PublishFullDates(___fullDates);
                                break; //test
                            }
                        }
                    }
                  
                }


            }
        }



        public async Task<string> SendEmail()
        {

            ApiServices apiServices = new ApiServices();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/StudentReservedAppointments/GetSpecieficStaffEmail?staffName={0}", _staffName);
            string staffemail = await apiServices.GetStaffEmail(url);



            string url_2 = string.Format("https://newmysofapplication.conveyor.cloud/api/StudentReservedAppointments/GetSpecieficstudentEmail?ID={0}", _studentID);
            string studentemail = await apiServices.GetStudentEmail(url_2);

            try
            {

                MailMessage mail = new MailMessage();


                mail.From = new MailAddress("safa.199841@gmail.com");
                mail.To.Add(staffemail);//staff
                mail.To.Add(studentemail);//student
                mail.Subject = "Booking Appointment _student: ";
                mail.Body = _studentID+" has booked an appoitment at\n " + selectedTime + " at date " + calendar.SelectedDate.ToString().Substring(0, calendar.SelectedDate.ToString().Length - 11) + "\n" + " in "+ serviceType+" Your role number: "+ _rolenumber;

                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                //
                NetworkCredential nc = new NetworkCredential("email", "password");
                // SmtpServer.Credentials = new System.Net.NetworkCredential("email", "password");
                SmtpServer.Credentials = nc;
                SmtpServer.Send(mail);
                return "true";
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return "false";
            }
        }

        //
        //number with time
        bool _status;

        string selectedTime;
        int _rolenumber;
        private void LVLostThings_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            TimeSlotDiv selsectedTime = e.SelectedItem as TimeSlotDiv;
            List<TimeSlotDiv> __timeSlotDivs = new List<TimeSlotDiv>();
            __timeSlotDivs.Add(selsectedTime);

            if (selsectedTime != null)
            {
                foreach (var time in __timeSlotDivs)
                {
                    selectedTime = time.time;
                    _rolenumber = time.roleNumber;
                }
                _status = false;

            }



        }





































        /////////////////////////////////////////////////////////////////

       
        //has to jump to page rather than the choosing page

        //Get Appointment



      



    /*    public async void GetTimeSlots()
        {

            //send staff name to timelot and get the timeslots match id of staff

            ApiServices apiServices = new ApiServices();
            string url = string.Format("https://api-testingsof.conveyor.cloud/api/StudentReservedAppointments/GetSpecieficStaffTimeSlots?staffName={0}", _staffName);
            _timeSlots = await apiServices.GetTimeSlotsAfterDiv(url);
            
        }*/
        


       
       

        //number with time
      


       


       /* private void LVTimeslot_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            GetAppointment();
            var TSD = BindingContext as TimeSlotDiv;
            var timeSlotdive = e.Item as TimeSlotDiv;

            TSD.changeAvailability(timeSlotdive, status);

        }*/


        /*
        string d___;
        private void Handle_OnCalendarTapped(object sender, CalendarTappedEventArgs e)
        {
            LVTimeslot.IsVisible = true;
            d___ = e.DateTime.ToString();
            GettimeSlotDivs();
            GetAppointment();
        }
        */

      
       
    }
           

   

        }
