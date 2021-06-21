using System;
using System.Collections.Generic;
using System.Text;

namespace SOF_App.Models
{
   public class PostEvent_N
    {
        public int ID { get; set; }
        public string PublisherName { get; set; }
        public string Title { get; set; }
        public string Information { get; set; }
        public string ImagePath { get; set; }

        public string FullPathImage { get
            {
                if (string.IsNullOrEmpty(ImagePath))
                {
                    return string.Empty;
                }
                return string.Format("https://newmysofapplication.conveyor.cloud/{0}", ImagePath.Substring(2) );
            }
        }//?
        public object ImageArray { get; set; }
    }
}
