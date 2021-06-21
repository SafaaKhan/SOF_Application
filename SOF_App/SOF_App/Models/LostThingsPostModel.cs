using System;
using System.Collections.Generic;
using System.Text;

namespace SOF_App.Models
{
   public class LostThingsPostModel:RegisterModel
    {
        public int ID { get; set; }
        public string ResponsibleName { get; set; }
      
        public string Information { get; set; }
        public DateTime Date { get; set; }

        public List<RegisterMember> registerMembers { get; set; }
        

    }
}
