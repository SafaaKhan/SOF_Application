using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SOF_App.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SOF_App.Services
{
   public class ApiServices
    {
        public  async Task<bool> RegisterUser(string name, string id, string passworrd, string confirmPassword, string email, string memberType, string staffservic ,string staffDepartment)
        {
            RegisterMember registerMember = new RegisterMember()
            {
                Name = name,
                ID = id,
                Password = passworrd, 
                ConfirmPassword = confirmPassword,
                Email = email,
                MemberType = memberType
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registerMember);//url
            var content = new StringContent(json, Encoding.UTF8, "application/json" );
            var formatting = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/Post?memberType={0}&__staffService={1}&_staffDepartment={2}", memberType,staffservic,staffDepartment);
            var response = await httpClient.PostAsync(formatting, content);
             return response.IsSuccessStatusCode;
           // var test= JsonConvert.DeserializeObject<bool>(response.ToString());
            //return test;
            //have to correct it
        }

        public async Task<bool> LoginUser(string id, string password)
        {
            var keysVulues = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username",id),
                new KeyValuePair<string, string>("password",password),
              
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "https://newmysofapplication.conveyor.cloud/Token");
            request.Content = new FormUrlEncodedContent(keysVulues);
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
           JObject jObject= JsonConvert.DeserializeObject<dynamic>(content);
           //Settings.AccessToken= jObject.Value<string>("access_token");
            Settings.ID = id;
            Settings.Password = password;


            return response.IsSuccessStatusCode;


        }

        //for logout
        public void externalLogin(string id, string password, string type)
        {
            Settings.Type = type;
            Settings.ID = id;
            Settings.Password = password;

        }


        //General login
        public async Task<string> GeneralLogin(string url)
        {
           

            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                var response_data = response.Content.ReadAsStringAsync().Result;
                return response_data;
            
            }
            catch (Exception ex)
            {
                var error = ex.Message;//??
                return null;
            }

        }

        



        //Get the events
        public async Task<List<PostEvent_N>> GetEventsN()
        {
            var httpClient = new HttpClient();
            var EventsNUrl = "https://newmysofapplication.conveyor.cloud/api/PostingEvents_N"; //allow imagee
            var json = await httpClient.GetStringAsync(EventsNUrl);
            return JsonConvert.DeserializeObject<List<PostEvent_N>>(json);

        }

        //Get all staff names
        public async Task<List<RegisterMember>> GetAllStaffNames()
        {
            var httpClient = new HttpClient();
            var namesUrl = "https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStaffName";
            var json = await httpClient.GetStringAsync(namesUrl);
            return JsonConvert.DeserializeObject<List<RegisterMember>>(json);

        }

        //Publish Event
        public async Task<bool> PublishEventN(PostEvent_N postEvent_N)
        {
            var json = JsonConvert.SerializeObject(postEvent_N);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var EventsNUrl = "https://newmysofapplication.conveyor.cloud/api/PostingEvents_N"; //allow imagee
            var response = await httpClient.PostAsync(EventsNUrl, content);
            return response.IsSuccessStatusCode;

        }


        //Get staffService
        public async Task<bool> GetStaffService(string url)
        {
           
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            return response.IsSuccessStatusCode;

        }

        //Get the LostThings
        public async Task<List<LostThingsPostModel>> GetLostThing()
        {
            var httpClient = new HttpClient();
            var LostThingsUrl = "https://newmysofapplication.conveyor.cloud/api/LostPostings/Get"; //allow imagee
            var json = await httpClient.GetStringAsync(LostThingsUrl);
            return JsonConvert.DeserializeObject<List<LostThingsPostModel>>(json);

        }


        //Publish Lost things
        public async Task<bool> PublishLostThing(LostThingsPostModel lostThingsPost , string memberID)
        {
            var json = JsonConvert.SerializeObject(lostThingsPost);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var LostThingsUrl = string.Format("https://newmysofapplication.conveyor.cloud/api/LostPostings/Post?_memberID={0}", memberID); //allow imagee
            var response = await httpClient.PostAsync(LostThingsUrl, content);
            return response.IsSuccessStatusCode;

        }

        //Get the events
        public async Task<List<MemberInfo>> GetMemberInfos()
        {
            var httpClient = new HttpClient();
            var MembersNUrl = "https://newmysofapplication.conveyor.cloud/api/Members"; //allow imagee
            var json = await httpClient.GetStringAsync(MembersNUrl);
            return JsonConvert.DeserializeObject<List<MemberInfo>>(json);

        }


        //Get studentReservedAppointment
        public async Task<List<StudentReservedAppointment>> GetStudentReservedAppointment(string staffName)//
        {
            var httpClient = new HttpClient();
            var Url = string.Format("https://newmysofapplication.conveyor.cloud/api/StudentReservedAppointments?staffName={0}", staffName);
            var json = await httpClient.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<List<StudentReservedAppointment>>(json);

        }

        //Get timeSlotDivInfo
        public async Task<List<TimeSlotDiv>> GetTimeSlotDivInfo(string staffName, string service)//
        {
            var httpClient = new HttpClient();
            var Url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlotDivs?staffName={0}&service={1}", staffName, service);
            var json = await httpClient.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<List<TimeSlotDiv>>(json);

        }

        public async Task<List<TimeSlotDiv>> GetTimeSlotDivInfo_2(string staffName)//
        {
            var httpClient = new HttpClient();
            var Url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlotDivs/GetTimeSlotDivs_2?staffName={0}", staffName);
            var json = await httpClient.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<List<TimeSlotDiv>>(json);

        }

        //Get time slots info start and end date
        public async Task<List<TimeSlot>> GetTimeSlotInfo(string staffName ,string service)//
        {
            var httpClient = new HttpClient();
            var Url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots3?staffName={0}&service={1}", staffName, service);
            var json = await httpClient.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<List<TimeSlot>>(json);

        }

        //Get time slots info start and end date
        public async Task<List<TimeSlot>> GetTimeSlotInfo_2(string id)//
        {
            var httpClient = new HttpClient();
            var Url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetTimeSlots_2?id={0}", id);
            var json = await httpClient.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<List<TimeSlot>>(json);

        }

        //Get club member
        public async Task<List<RegisterMember>> GetClubMember()
        {
            var httpClient = new HttpClient();
            var clubMembers = "https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetClubMember"; 
            var json = await httpClient.GetStringAsync(clubMembers);
            return JsonConvert.DeserializeObject<List<RegisterMember>>(json);
          // return clubMembers;
        }


        //Get Member Email
        public async Task<List<RegisterMember>> GetMemberEmail(string url)
        {
            var httpClient = new HttpClient();
            var member = url;
            var json = await httpClient.GetStringAsync(member);
            return JsonConvert.DeserializeObject<List<RegisterMember>>(json);
        }


        //Get Member Email_2
        public async Task<string> GetMemberEmail_2(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var response_data = response.Content.ReadAsStringAsync().Result;
            return response_data;
        
        }


        //Get Date_appointment
        public async Task<List<string>> GetDate(string staffName)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/TimeSlots/GetDate?staffName={0}", staffName); 
            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<string>>(json);

        }

        //Get Member name
        public async Task<string> GetMemberName(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var response_data = response.Content.ReadAsStringAsync().Result;
            return response_data;

        }

        //Get security member
        public async Task<List<RegisterMember>> GetSecurityMember()
        {
            var httpClient = new HttpClient();
           var SecurityMembers = "https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetSecurityMember"; 
            var json = await httpClient.GetStringAsync(SecurityMembers);
            return JsonConvert.DeserializeObject<List<RegisterMember>>(json);
            
        }

      //Get adminstrator member
        public async Task<List<RegisterMember>> GetadminstratorMember()
        {
            var httpClient = new HttpClient();
            var adminstratorMembers = "https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetAdminstratorMember";
            var json = await httpClient.GetStringAsync(adminstratorMembers);
            return JsonConvert.DeserializeObject<List<RegisterMember>>(json);

        }


        //Get the departments
        public async Task<List<Department>> GetDepartments()
        {
            var httpClient = new HttpClient();
            var DepartmentNUrl = "https://newmysofapplication.conveyor.cloud/api/Departments/GetDepartments"; 
            var json = await httpClient.GetStringAsync(DepartmentNUrl);
            return JsonConvert.DeserializeObject<List<Department>>(json);

        }


        //Get staff service
         public async Task<List<string>> GetStaffServices()
        {
            var httpClient = new HttpClient();
            var ServiceNUrl = "https://newmysofapplication.conveyor.cloud/api/ServicesOfStaffs"; 
            var json = await httpClient.GetStringAsync(ServiceNUrl);
            return   JsonConvert.DeserializeObject<List<string>>(json); ;
        }

        //Get staff service
        public async Task<List<string>> GetStaffName(string serviceType,string departmentType)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/ServicesOfStaffs/GetNameOfStaffs?serviceType={0}&departmentType={1}", serviceType,departmentType);
            var ServiceNUrl = url;
            var json = await httpClient.GetStringAsync(ServiceNUrl);
            return JsonConvert.DeserializeObject<List<string>>(json); ;
        }


        
        //Get the timeSlots
        public async Task<List<TimeSlot>> GetTimeSlots()
        {
            var httpClient = new HttpClient();
            var DepartmentNUrl = "https://newmysofapplication.conveyor.cloud/api/TimeSlots"; //allow imagee
            var json = await httpClient.GetStringAsync(DepartmentNUrl);
            return JsonConvert.DeserializeObject<List<TimeSlot>>(json);

        }

        //Get the timeSlots
        public async Task<List<string>> GetTimeSlotsAfterDiv(string url)
        {
            var httpClient = new HttpClient();
            var DepartmentNUrl = url; 
            var json = await httpClient.GetStringAsync(DepartmentNUrl);
            return JsonConvert.DeserializeObject<List<string>>(json);

        }

        //Get Staff Email
        public async Task<string> GetStaffEmail(string url)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<string>(json);

        }

        //Get student Email
        public async Task<string> GetStudentEmail(string url)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<string>(json);

        }


        public async Task<string> GetAdminstratorService(string url)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<string>(json);

        }

        //Get the name
        public async Task<List<string>> GetName()
        {
            var httpClient = new HttpClient();
          
            var json = await httpClient.GetStringAsync("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStudentMember2");
            return JsonConvert.DeserializeObject<List<string>>(json);

        }

        //Publish Student Reserved Appointment
        public async Task<bool> PublishStudentReservedAppointment(StudentReservedAppointment studentReservedAppointment)
        {
            var json = JsonConvert.SerializeObject(studentReservedAppointment);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://newmysofapplication.conveyor.cloud/api/StudentReservedAppointments/ReservedApoointment", content);
            return response.IsSuccessStatusCode;

        }

        //Update appointment state=Done
        public async void UpdateAppointmentState(int id, string who)
        {
            try
            {
                var httpClient = new HttpClient();
                string url = string.Format("https://newmysofapplication.conveyor.cloud/api/StudentReservedAppointments/UpdateState?id={0}&who={1}", id, who);
                var response= await httpClient.PutAsync(url,null);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                
            }

        }

        // disable
        public async Task<bool> UpdateAppointmentDisable(string url)
        {
            try
            {
                var httpClient = new HttpClient();
               
                var response = await httpClient.PutAsync(url, null);
                return true;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return false;

            }

        }


        //Update appointment state=Cancel
        public async void CancelAppointmentState(int id , string who)
        {
            try
            {
                var httpClient = new HttpClient();
                string url = string.Format("https://newmysofapplication.conveyor.cloud/api/StudentReservedAppointments/CancelState?id={0}&who={1}", id, who);
                var response = await httpClient.PutAsync(url, null);
            }
            catch (Exception ex)
            {
                var error = ex.Message;

            }

        }

        //send the start end and slot time from user and get the no. of slots
        public async Task<string> GetNumberOfTimeSlot(string url)
        {
            try
            {
                var httpClient = new HttpClient();

                return await httpClient.GetStringAsync(url);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return "Invalid";
            }
        }



        //https://api-testingsof.conveyor.cloud/api/RegisterMembers/GetStudentMember
        //https://api-testingsof.conveyor.cloud/api/RegisterMembers/GetStudentMember_2
        //Get the studentAppointmentInfo_waiting
        public async Task<List<StudentReservedAppointment>> GetStudentAppointmentInfo(string staffID)
        {//https://api-testingsof.conveyor.cloud/api/StudentReservedAppointments
            var httpClient = new HttpClient();//https://api-testingsof.conveyor.cloud/api/RegisterMembers/GetCMember
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStudentMember_2?staffID={0}", staffID);
          //  var studentAppointmentInfoUrl = "https://api-testingsof.conveyor.cloud/api/RegisterMembers/GetStudentMember_2"; //allow imagee
                var json = await httpClient.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<StudentReservedAppointment>>(json);

            }

        // Get Staff Name
        public async Task<string> GetStaffName(string staffID)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStaffName?staffID={0}", staffID);
          
            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<string>(json);

        }

        //https://api-testingsof.conveyor.cloud/api/Trackings/UpdateState?_staffID=288999&_status=Available


        public async void PostTrackingStaffStatus(string staffID , string status)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/Trackings/UpdateState?_staffID={0}&_status={1}", staffID, status);

            var json = await httpClient.PutAsync(url,null);
            
            
        }

        public async Task<string> GetStafftrackingstatus(string staffID)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/Trackings/GetTrackingStaffStatus?staffID={0}", staffID);

            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<string>(json);

        }




        //Get the studentAppointmentInfo_waiting
        public async Task<List<StudentReservedAppointment>> GetStudentAppointmentInfoStu(string studentID)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStudentMemberStudent_2?studentID={0}", studentID);
           
            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<StudentReservedAppointment>>(json);

        }

        //Get the staffEmail
        public async Task<string> GetstaffEmail(string staffName)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStaffEmail?staffName={0}", staffName);

            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<string>(json);

        }

        //Get the studentAppointmentInfo_Done
        public async Task<List<StudentReservedAppointment>> GetStudentAppointmentInfo_Done(string staffID)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStudentMember_3?staffID={0}", staffID);
           
            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<StudentReservedAppointment>>(json);

        }

        //Get the studentAppointmentInfo_Done
        public async Task<List<StudentReservedAppointment>> GetStudentAppointmentInfoStu_Done(string studentID)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStudentMember_3Student?studentID={0}", studentID);

            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<StudentReservedAppointment>>(json);

        }
        //Get the studentAppointmentInfo_Cancel
        public async Task<List<StudentReservedAppointment>> GetStudentAppointmentInfo_Cancel(string staffID)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStudentMember_4?staffID={0}", staffID);

            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<StudentReservedAppointment>>(json);

        }


        //Get the studentAppointmentInfo_Cancel
        public async Task<List<StudentReservedAppointment>> GetStudentAppointmentInfo_CancelStu(string studentID)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/RegisterMembers/GetStudentMemberStudent_4?studentID={0}", studentID);

            var json = await httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<StudentReservedAppointment>>(json);

        }


        //Publish FullDates
        public async Task<bool> PublishFullDates(FullDates fullDates)
        {
            var json = JsonConvert.SerializeObject(fullDates);
            var httpClient = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var FullDatesUrl = "https://newmysofapplication.conveyor.cloud/api/FullDates/Post";
            var response = await httpClient.PostAsync(FullDatesUrl, content);
            return response.IsSuccessStatusCode;

        }

        //deleteAppoitment
        public async void DeleteAppoitment(List<int> IDs)
        {
            try
            {
                
                string part = "";
                int count = 0;
                foreach (int id in IDs)
                {
                    part += string.Format("ids[]={0}", id);
                    count++;
                    if (count < IDs.Count)
                    {
                        part += "&";
                    }
                    //ids[]=4
                }
                var httpClient = new HttpClient();
                string concatenation_url = "https://newmysofapplication.conveyor.cloud/api/StudentReservedAppointments/DeleteAppoitment?" + part;
               // string url = string.Format("https://api-testingsof.conveyor.cloud/api/StudentReservedAppointments/DeleteAppoitment?ids={0}", IDs);
                var response= await httpClient.DeleteAsync(concatenation_url);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
               
            }
        }


        //delete Services
        public async void DeleteServices(List<int> IDs)
        {
            try
            {

                string part = "";
                int count = 0;
                foreach (int id in IDs)
                {
                    part += string.Format("ids[]={0}", id);
                    count++;
                    if (count < IDs.Count)
                    {
                        part += "&";
                    }
                    //ids[]=4
                }
                var httpClient = new HttpClient();
                string concatenation_url = "https://newmysofapplication.conveyor.cloud/api/StudentReservedAppointments/Deleteservice?" + part;
              
                var response = await httpClient.DeleteAsync(concatenation_url);
            }
            catch (Exception ex)
            {
                var error = ex.Message;

            }
        }


        //delete specific service
        public async Task<bool> DeleteSpecificService(int id)
        {
            try
            {

               
                var httpClient = new HttpClient();
                string url = string.Format("https://newmysofapplication.conveyor.cloud/api/StudentReservedAppointments/DeleteSpecificService?id={0}", id);
                var response = await httpClient.DeleteAsync(url);
                return true;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return false;

            }
        }













        //GetFullDateInfo
        public async Task<List<FullDates>> GetFullDateInfo(string staffname)
        {
            var httpClient = new HttpClient();
            string url = string.Format("https://newmysofapplication.conveyor.cloud/api/FullDates?staffName={0}", staffname);
            string fullDatesUrl = url;
            var json = await httpClient.GetStringAsync(fullDatesUrl);
            return JsonConvert.DeserializeObject<List<FullDates>>(json);

        }


        ///////////////////////////////////////////////////////////
        public async Task<bool> ApplicationForm(string EntSemesters, string EntCenter, string EntCivilID, string EntArabicName,
         string EntEnglishName, string EntArabicSecond, string EntEnglishSecond, string EntArabicThird, string EntEnglishThird, string EntArabicFamily,
         string EntEnglishFamily, string EntMale, string EntFemale, string EntGregorian, string EntHijri, string EntBirthPlace, string EntNationality,
         string EntEXPDateID, string EntIDType, string EntPhoneNumH, string EntMobileNum, string EntEmail,
         string EntArea, string EntCity, string EntArStreet, string EntEnStreet, string EntArBuilding, string EntEnBuilding, string EntArFloor, string EntEnFloor,
         string EntArtSience, string EntCuorses, string EntAverage, string EntGraduateYear, string EntCountry, string EntEnglishLevel, string EntQyasGrade,
         string EntTofelTest, string EntProgram, string EntTrack, string EntHaveAjob, string EntKnowingOfAOU,
         string EntHaveDisAbility, string EntContactName, string EntPhoneNumEm)

        {
            var FormModel = new FormModel()
            {
                EntSemesters = EntSemesters,
                EntCenter = EntCenter,
                EntCivilID = EntCivilID,
                EntArabicName = EntArabicName,
                EntEnglishName = EntEnglishName,
                EntArabicSecond = EntArabicSecond,
                EntEnglishSecond = EntEnglishSecond,
                EntArabicThird = EntArabicThird,
                EntEnglishThird = EntEnglishThird,
                EntArabicFamily = EntArabicFamily,
                EntEnglishFamily = EntEnglishFamily,
                EntMale = EntMale,
                EntFemale = EntFemale,
                EntGregorian = EntGregorian,
                EntHijri = EntHijri,
                EntBirthPlace = EntBirthPlace,
                EntNationality = EntNationality,
                EntEXPDateID = EntEXPDateID,
                EntIDType = EntIDType,
                EntPhoneNumH = EntPhoneNumH,
                EntMobileNum = EntMobileNum,
                EntEmail = EntEmail,
                EntArea = EntArea,
                EntCity = EntCity,
                EntArStreet = EntArStreet,
                EntEnStreet = EntEnStreet,
                EntArBuilding = EntArBuilding,
                EntEnBuilding = EntEnBuilding,
                EntArFloor = EntArFloor,
                EntEnFloor = EntEnFloor,
                EntArtSience = EntArtSience,
                EntCuorses = EntCuorses,
                EntAverage = EntAverage,
                EntGraduateYear = EntGraduateYear,
                EntCountry = EntCountry,
                EntEnglishLevel = EntEnglishLevel,
                EntQyasGrade = EntQyasGrade,
                EntTofelTest = EntTofelTest,
                EntProgram = EntProgram,
                EntTrack = EntTrack,
                EntHaveAjob = EntHaveAjob,
                EntKnowingOfAOU = EntKnowingOfAOU,
                EntHaveDisAbility = EntHaveDisAbility,
                EntContactName = EntContactName,
                EntPhoneNumEm = EntPhoneNumEm


            };




            var HttpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(FormModel);
            var Content = new StringContent(json, Encoding.UTF8, "application/json");
            var responce = await HttpClient.PostAsync("https://newmysofapplication.conveyor.cloud/api/RegistrationForms/Post", Content);
            return responce.IsSuccessStatusCode;
        }//https://api-testingsof.conveyor.cloud/
        //https://localhost:44386/

       internal Task<bool> ApplicationForm(int selectedIndex, string title1, string text1, string text2, string text3,
            string text4, string text5, string text6, string text7, string text8, string text9, string text10, string text11,
            string text12, string text13, string text14, string text15, string title2, string text16, string text17,
            string text18, string text19, string text20, string text21, string text22, string text23, string text24,
            string text25, string text26, string text27, string text28, string title3, string text29, string text30,
            string text31, string title4, string text32, string text33, string title5, string text34, string text35,
            string text36, string title6, string text37, string text38)
        {
            throw new NotImplementedException();
        }


        //New Work
        #region New Work

        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            DateParseHandling = DateParseHandling.DateTime,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Objects
        };
        private static HttpClient CreateHttpClient(string token = "")
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                httpClient.DefaultRequestHeaders.Add("Token", token);
            }


            return httpClient;
        }
        public static async Task<T> GetAsync<T>(string uri, string token = "")
        {
            using (HttpClient httpClient = CreateHttpClient(token))
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(uri))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        string err = await response.Content.ReadAsStringAsync();
                        throw new Exception(err);
                    }
                    else
                    {

                        string serialized = await response.Content.ReadAsStringAsync();
                        T result = await Task.Run(() => JsonConvert.DeserializeObject<T>(serialized, _serializerSettings));
                        return result;
                    }
                }
            }
        }

        public static async Task<string> GetPhrase(string url)
        {
            var httpClient = new HttpClient();
           
            string fullDatesUrl = url;
            var json = await httpClient.GetStringAsync(fullDatesUrl);
            return JsonConvert.DeserializeObject<string>(json);

        }


        public static async Task<TResult> PostAsync<TResult>(string uri, object data, string token = "", string header = "")
        {
            TResult result;
            HttpClient httpClient = CreateHttpClient(token);
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);


            if (!response.IsSuccessStatusCode)
            {
                var serialized = await response.Content.ReadAsStringAsync();
                throw new Exception(serialized);
            }
            else
            {
                string serialized = await response.Content.ReadAsStringAsync();

                result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            }
            return result;

        }
        //public static async Task<Boolean> PostAsync(string uri, object data, string token = "", string header = "")
        //{ 
        //    HttpClient httpClient = CreateHttpClient(token);
        //    var json = JsonConvert.SerializeObject(data);
        //    var content = new StringContent(json);
        //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    HttpResponseMessage response = await httpClient.PostAsync(uri, content);

        //    return response.IsSuccessStatusCode; 
        //}
        #endregion
        /////////////////////////////////////////////


    }
}

