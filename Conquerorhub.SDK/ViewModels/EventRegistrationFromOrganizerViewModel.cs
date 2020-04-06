using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.ViewModels
{
    public class EventAwardandRewardViewModel

    {
        public System.Guid EventId { get; set; }

        public string OrganizerId { get; set; }
        public string FirstPrize { get; set; }
        public string SecondPrize { get; set; }
        public string ThirdPrize { get; set; }
        public Nullable<int> EventStatus { get; set; }
    }
    public class OrganizerRegisterAbouteventViewModel
    {
        public System.Guid EventId { get; set; }

        public string OrganizerId { get; set; }
        public string NameofOrganizer { get; set; }
        public string EventName { get; set; }
        public ModeofEvent1 modeofevent { get; set; }
        public TypeofEvent1 TypeOfEvent { get; set; }
        public int SubTypeOfEvent { get; set; }
        public Nullable<int> EventStatus { get; set; }
        public ExpectingVideoorImage1 ImageorVideo { get; set; }
        public Nullable<int> Eventfee { get; set; }
        public Nullable<bool> PaymentStatus { get; set; }


    }
    public class OrganizerRegisterAboutparticipantViewModel
    {
        public Guid Result { get; set; }

        public string OrganizerId { get; set; }
        public System.Guid EventId { get; set; }
        public streamofparticipants1 StreamOfParticipants { get; set; }
        public Agegroup1 AgeGroup { get; set; }
        public Numberofteam1 MaxnumofTeam { get; set; }
        public teamsize1 numofParticipantsinteam { get; set; }
        public Nullable<int> EventStatus { get; set; }

    }
    public class ImportantDatesofEventViewModel
    {
        public System.Guid EventId { get; set; }

        public string OrganizerId { get; set; }

        public Nullable<System.DateTime> StartofEventRegistration { get; set; }
        public Nullable<System.DateTime> EndOfEventRegistration { get; set; }
        public Nullable<System.DateTime> StartofVideoUpload { get; set; }
        public Nullable<System.DateTime> EndOfVideoUpload { get; set; }
        public Nullable<System.DateTime> StartOfValuationfromvoters { get; set; }
        public Nullable<System.DateTime> EndofValuationFromVoters { get; set; }
        public Nullable<System.DateTime> ResultDate { get; set; }
        public Nullable<int> EventStatus { get; set; }
    }


    public class AboutParticipants
    {
        public Guid Result { get; set; }

        public string OrganizerId { get; set; }
        public System.Guid EventId { get; set; }
        public streamofparticipants1 StreamOfParticipants { get; set; }
        public Agegroup1 AgeGroup { get; set; }
        public Numberofteam1 MaxnumofTeam { get; set; }
        public teamsize1 numofParticipantsinteam { get; set; }
        public Nullable<int> EventStatus { get; set; }
    }
    public enum streamofparticipants1
    {
        none = 0,
        School = 1,
        Preuniversity = 2,
        UnderGraduate = 3,
        PostGraduate = 4
    }
    public enum Agegroup1
    {
        none = 0,
        Less_than_18 = 1,
        Greaterthan_18_Lessthan_50 = 2,
        SeniorCitizens_greaterthan_50 = 3,
        others = 4

    }
    public enum Numberofteam1
    {
        none = 0,
        Less_than_20 = 1,
        Less_than_50 = 2,
        Less_than_100 = 3,
        Less_than_200 = 4,
        No_Limits = 5,
        Custom_limit = 6
    }
    public enum teamsize1
    {
        none = 0,
        solo = 1,
        less_than_5 = 2,
        Custom_Limit = 3
    }
    public enum ModeofEvent1
    {
        Online = 1,
        Offline = 2,
        Both=3
    }
    public enum TypeofEvent1
    {
        Arts = 1,
        Business = 2,
        Cultural = 3,
        Technical = 4,
        Awareness = 5,
        Workshop = 6
    }
    public enum ExpectingVideoorImage1
    {
        Image = 1,
        Video = 2
    }
}
