using SOF_App.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOF_App.Models
{
  public class FormModel
    {
        public int ID { get; set; }
        public string EntSemesters { get; set; }
        public string EntCenter { get; set; }
        public string EntCivilID { get; set; }
        public string EntArabicName { get; set; }
        public string EntEnglishName { get; set; }
        public string EntEnglishSecond { get; set; }
        public string EntArabicSecond { get; set; }
        public string EntArabicThird { get; set; }
        public string EntEnglishThird { get; set; }
        public string EntArabicFamily { get; set; }
        public string EntEnglishFamily { get; set; }
        public string EntGregorian { get; set; }
        public string EntHijri { get; set; }
        public string EntBirthDay { get; set; }
        public string EntBirthPlace { get; set; }
        public string EntNationality { get; set; }
        public string EntEXPDateID { get; set; }
        public string EntIDType { get; set; }
        public string EntPhoneNumH { get; set; }
        public string EntMobileNum { get; set; }
        public string EntEmail { get; set; }
        public string EntArea { get; set; }
        public string EntCity { get; set; }
        public string EntArStreet { get; set; }
        public string EntEnStreet { get; set; }
        public string EntArBuilding { get; set; }
        public string EntEnBuilding { get; set; }
        public string EntArFloor { get; set; }
        public string EntEnFloor { get; set; }
        public string EntArtSience { get; set; }
        public string EntAverage { get; set; }
        public string EntGraduateYear { get; set; }
        public string EntCountry { get; set; }
        public string EntEnglishLevel { get; set; }
        public string EntQyasGrade { get; set; }
        public string EntTofelTest { get; set; }
        public string EntProgram { get; set; }
        public string EntTrack { get; set; }
        public string EntHaveAjob { get; set; }
        public string EntKnowingOfAOU { get; set; }
        public string EntHaveDisAbility { get; set; }
        public string EntContactName { get; set; }
        public string EntPhoneNumEm { get; set; }
        public string EntMale { get; internal set; }
        public string EntFemale { get; set; }
        public string EntCuorses { get; internal set; }



        public string EntCertificateType { get; set; }
        public String FilePath { get; set; }
        public int Status { get; set; }


       
public String EntStatus { get { return Status == 0 ? "Waiting for review" : Status == 1 ? "Approved" : "Declined"; } }
        public Xamarin.Forms.Color BackColor => Status == 0 ? Xamarin.Forms.Color.Black : Status == 1 ? Xamarin.Forms.Color.Green : Xamarin.Forms.Color.Red;
    }
}
