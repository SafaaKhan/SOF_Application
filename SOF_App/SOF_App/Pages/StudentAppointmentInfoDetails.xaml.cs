using Plugin.Messaging;
using SOF_App.Models;
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
    public partial class StudentAppointmentInfoDetails : ContentPage
    {
        string _email;
        public StudentAppointmentInfoDetails(StudentReservedAppointment studentReservedAppointment)
        {
            InitializeComponent();

            var assembly = typeof(StudentAppointmentInfoDetails);
            SofIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.SOFLogoAOU.png", assembly);
            EmailIcon.Source = ImageSource.FromResource("SOF_App.Assets.Image.email.png", assembly);
            LblName.Text = studentReservedAppointment.studentName;
            LblID.Text = studentReservedAppointment.studentID;
           
           
            _email = studentReservedAppointment.StudentEmail;

        }

        private void TapEmail_Tapped(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;//email from the labtop?????/
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail( _email, "Add a subject", "Write email body");


            }
        }
    }
}