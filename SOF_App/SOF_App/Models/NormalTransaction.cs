using System;
using System.Collections.Generic;
using System.Text;

namespace SOF_App.Models
{
   public class NormalTransaction
    {

        public int ID { get; set; }

        public string lbContinuing { get; set; }
        public string EntIdC { get; set; }
        public string EntEmailC { get; set; }
        public string EntNameC { get; set; }
        public string lbGraduate { get; set; }
        public string EntIdG { get; set; }
        public string EntEmailG { get; set; }
        public string MajorC { get; set; }
        public string EntNameG { get; set; }
        public string EntContinuingSt { get; set; }
        public string EntGraduateSt { get; set; }
        public String FilePath { get; set; }
        public String GraduatedORContinuing { get; set; }

        public String EntcontinuosTransaction { get; set; }
        public String EntGraduateTransaction { get; set; }
        public int Status { get; set; }
        public String FileExtension { get; set; }

        public String EntName
        {
            get
            {
                return GraduatedORContinuing == "Graduate Student" ? EntNameG : EntNameC;
            }
        }

        public String EntId
        {
            get
            {
                return GraduatedORContinuing == "Graduate Student" ? EntIdG : EntIdC;
            }
        }
        public String EntStatus { get { return Status == 0 ? "Waiting for review" : Status == 1 ? "Approved" : "Declined"; } }
        public Xamarin.Forms.Color BackColor => Status == 0 ? Xamarin.Forms.Color.Black : Status == 1 ? Xamarin.Forms.Color.Green : Xamarin.Forms.Color.Red;
    }
}
