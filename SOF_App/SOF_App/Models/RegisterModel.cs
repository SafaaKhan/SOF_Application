using System;
using System.Collections.Generic;
using System.Text;

namespace SOF_App.Models
{
  public  class RegisterModel
    {
        public string ID { get; set; }
      //  public int ID { get; set; }
    //    public string MemberId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }

        public virtual List<LostThingsPostModel> LostPostings { get; set; }
        public virtual List<StudentReservedAppointment> StudentReservedAppointments { get; set; }
    }
}
