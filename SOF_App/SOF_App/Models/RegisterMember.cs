using System;
using System.Collections.Generic;
using System.Text;

namespace SOF_App.Models
{
   public class RegisterMember
    {
        public string Name { get; set; }

        
        public string ID { get; set; }

        
        
        public string Email { get; set; }

        public string Password { get; set; }

       
        public string ConfirmPassword { get; set; }


        public string MemberType { get; set; }

        public List<LostThingsPostModel> LostThingsPostModels { get; set; }
        public List<StudentReservedAppointment> studentReservedAppointments { get; set; }
    }
}
