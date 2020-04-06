using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Conquerorhub.SDK.ViewModels
{
   public class ParticipationRegistrationViewModel
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> EventId { get; set; }
        public string OrganizerId { get; set; }
        public string ParticipantId { get; set; }
        public string Name { get; set; }
        public string CollegeorSchool { get; set; }
        public string Qualification { get; set; }
        public Nullable<System.DateTime> DateOfBirthh { get; set; }
        public Nullable<long> ContactNumber { get; set; }
        public string About_Self { get; set; }
        public modeofcompetation Modeofcompitetion { get; set; }
        public Guid Result { get; set; }
        public Registrationstatus RegistrationStatus { get; set; }
        public Nullable<int> OTP { get; set; }
        public Nullable<int> ParticipantStatus { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public Nullable<System.Guid> VideoId { get; set; }
        public Nullable<int> EventStatus { get; set; }
        public string FileName { get; set; }
        public HttpPostedFileBase PostedFile { get; set; }

    }

    public enum modeofcompetation
    {
        online = 1,
        offline = 2
    }

    public enum Registrationstatus
    {
        Registered = 1,
        Paymentincomplete = 2,
        //PaymentComplete=3,
        //Particpated=4,
        NotParticipated = 5

    }
}
